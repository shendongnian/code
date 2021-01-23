        string myXMLfile = @"xml.xml";
        DataSet ds = new DataSet();
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(myXMLfile);
            var runners = doc.SelectNodes("/Runner");
            foreach (XmlNode runner in runners)
            {
                foreach (XmlNode child in runner.ChildNodes)
                {
                    for (int i = 0; i < child.Attributes.Count; i++)
                    {
                        var at =doc.CreateAttribute(child.Name + child.Attributes[i].Name);
                        at.Value=child.Attributes[i].Value;
                        runner.Attributes.Append(at);
                    }
                    if (child.Name == "FixedOdds")
                    {
                        foreach (XmlNode book in child.ChildNodes)
                        {
                            for (int i = 0; i < book.Attributes.Count; i++)
                            {
                                var at = doc.CreateAttribute(book.Name + book.Attributes[i].Name);
                                at.Value = book.Attributes[i].Value;
                                runner.Attributes.Append(at);
                            }
                        }
                    }
                    // delete the attributes and the children nodes
                    child.RemoveAll();
                }
                // delete the child noeds
                while (runner.ChildNodes.Count > 0)
                {
                    runner.RemoveChild(runner.ChildNodes[0]);
                }
            }
            doc.Save("xml1.xml");
            ds.ReadXml("xml1.xml");
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[i].TableName);
            }
            dgvRunner.DataSource = ds;
            dgvRunner.DataMember = "Runner";
            //dgvWinOdds.DataSource = ds;
            //dgvWinOdds.DataMember = "WinOdds";
            //dgvPlaceOdds.DataSource = ds;
            //dgvPlaceOdds.DataMember = "PlaceOdds";
            //dgvFixedOdds.DataSource = ds;
            //dgvFixedOdds.DataMember = "FixedOdds";
        }
        catch (Exception)
        { }
            }
        }
