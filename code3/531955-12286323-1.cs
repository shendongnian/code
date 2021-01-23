    public class  contact 
    {
       public string Name { get; set; }
       public string Lname { get; set; }
       public string Email { get; set; }
    }
    List<contact> contact = new List<contact>();
            private void split()
            {
                var lines = File.ReadAllLines(@"txt file address");
                foreach (var line in lines)
                {
                   var splitline=line.Split(':');
               string name = splitline[2].Replace("Last", "");
               string lname = splitline[3].Replace("Email","");
               contact.Add(new contact { Name = name, Lname = lname, Email = splitline[4] });
                }
            }
