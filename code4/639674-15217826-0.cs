            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("D:....\\ASP_fifth_xml_file.xml");
            XmlNode node = xdoc.SelectSingleNode("//country");
            foreach (XmlNode element in node.ChildNodes)
            {
                richTextOutput_TextBox.Text += element.Name + ":" + element.InnerText + "\n";
                if (element.HasChildNodes)
                {
                    foreach (XmlNode subEl in element.ChildNodes)
                    {
                        richTextOutput_TextBox.Text += subEl.Name + ":" + subEl.InnerText + "\n";
                    }
                }
                richTextOutput_TextBox.Text += "\n \n \n";
            }
