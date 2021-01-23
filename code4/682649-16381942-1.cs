    public class Contact
    {        
       public string name;
        public bool Compare(Contact c)
        {
           return this.name.Equals(c.name);
        }
    }
