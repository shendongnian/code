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
    
        public bool Save()
        {
            //datalayer here
            //save the person class and return
          // true/false /or new ID (change return type)
        }
    
        public Person(int person_id)
        {
            //datalayer here
            //get the person from database and return a person class          
            personId = 10;
            Name= "Alex";  // set the public property value here
           
        }
    }
