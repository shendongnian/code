    foreach (XmlNode xn in xnList)
            {
                string date = xn.OfType<XmlNode>().FirstOrDefault(n => n.Name == "Date").FirstChild.Value;
                string id = xn.OfType<XmlNode>().FirstOrDefault(n => n.Name == "ID").FirstChild.Value;
                if (date == cari)
                {
                    this.listBox1.Items.AddRange(new object[,] {                    
                    //dateBox.Text,
                    dateBox.Text + "\r\n" + date, "sarabrown"});
                }
            }
