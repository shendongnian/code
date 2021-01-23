    class list
        {
    
           private List<Person> people;
           public List<Person> People
           {
               get { return people; }
               private set { people = value;}
           }
    
           public list()
           {
             people = new List<Person>();
           }
        }
