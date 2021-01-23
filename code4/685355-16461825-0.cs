        private void button1_Click(object sender, EventArgs e)
        {
          XDocument xDocument = new XDocument();
            try
            {
                // Add element to XML
                if (File.Exists(@"C:\Projects\serverlist.xml"))
                {
                    xDocument = XDocument.Load(@"C:\Projects\ServerList.xml");
                }
                else
                {
                    MessageBox.Show("No XML available!", "Error", MessageBoxButtons.OK);
                    // create new document
                    xDocument.Add(new XElement("servers"));
                }                
                XElement newServer = new XElement("server",
                        new XElement("hostname", txtHostName.Text),
                        new XElement("hostaddress", txtHostAddress.Text));
                newServer.SetAttributeValue("name", txtServerName.Text);
                xDocument.Root.Add(newServer);
                xDocument.Save(@"C:\Projects\Serverlist.xml");
                MessageBox.Show("Server Added!", "Server Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Error");
            }
        }
