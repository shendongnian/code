    string firstName, lastName;
    
    var data = from item in doc.Descendants("user")
               where item.Element("username").Value == "SomeUser"
               select new
               {
                   fname = item.Element("firstname").Value,
                   lname = item.Element("lastname").Value
               };
    
    var p = data.FirstOrDefault();
    if(p != null)
    {
        firstName = p.fname;
        lastName = p.lname;
    }
    else
    {
        MessageBox.Show("No such user found");
    }
