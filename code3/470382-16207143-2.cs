         protected void butRead_Click(object sender, EventArgs e)
        {
            XDocument xmlDoc = XDocument.Load(Server.MapPath("Persons.xml"));
            var persons = from person in xmlDoc.Descendants("Person")
                          select new
                          {
                              Name = person.Element("Name").Value,
                              City = person.Element("City").Value,
                              Sex = person.Element("Sex").Value,
                          };
            litResults.Text = "";
            foreach (var person in persons)
            {
                litResults.Text = litResults.Text + "Name: " + person.Name + "<br />";
                litResults.Text = litResults.Text + "City: " + person.City + "<br />";
                litResults.Text = litResults.Text + "Sex: " + person.Sex + "<br /><br />";
            }
            if (litResults.Text == "")
                litResults.Text = "No Results.";
        } 
