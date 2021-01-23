        protected void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtCity.Text == "" || txtSex.Text == "")
                {
                    lblStatus.Text = "Please complete the form.";
                }
                else
                {
                    XDocument xmlDoc = XDocument.Load(Server.MapPath("Persons.xml"));
                    xmlDoc.Element("Persons").Add(new XElement("Person", new XElement("Name", txtName.Text),
                    new XElement("City", txtCity.Text), new XElement("Sex", txtSex.Text)));
                    lblStatus.Text = "Data successfully added to XML file.";
                    xmlDoc.Save(Server.MapPath("Persons.xml"));
                    
                }
             }
            catch
                { 
                    lblStatus.Text = "Sorry, unable to process request. Please try again.";
                }
          } 
