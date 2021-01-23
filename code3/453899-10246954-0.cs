       bool read = false;
        
       void ReadXmDocument()
       {
           using(XmlDocument xmlDoc = new XmlDocument())
           {
              xmlDoc.Load("xmldoc.xml");
              foreach (XmlNode node in xmlDoc.SelectNodes("check/tick/mark"))
              {
                    Label l = new Label();
                    System.Drawing.Point l1 = new System.Drawing.Point(65, 48 + a);
                    l.Location = l1;
                    l.Text = node.SelectSingleNode("score").InnerText;
                    tabPage2.Controls.Add(l);
                    a += 25;
              }
              read = true;
           }
       }
       private void tabPage2_Enter(object sender, EventArgs e)
       {
           if(tabControl1.SelectedTab == tabPage2 && read == false) ReadXmlDocument();
       }
