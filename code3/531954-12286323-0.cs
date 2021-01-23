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
                   string[] name = splitline[2].Split(' ');
                   string[] lname = splitline[3].Split(' ');
                   contact.Add(new contact { Name = name[0], Lname = lname[0], Email = splitline[4] });
                }
            }
