    public class Person
    {
        int personId;       
    
        public int PersonId
        {
            get { return personId; }
        }    
        public string Name { set;get;}   
        public string LastName { set;get;}
        
    
        public Person()
        {
    
        }
    
        public static void Save(Person p)
        {
            //datalayer here
            //save the person class
        }
    
        public static Person GetPerson(int person_id)
        {
            //datalayer here
            //get the person from database and return a person class
            Person p = new Person();
            p.personId = 10;
            p.Name= "Alex";  // set the public property value here
            return p;
        }
    }
