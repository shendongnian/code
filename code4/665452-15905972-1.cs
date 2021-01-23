    namespace peoplePlaces
    {
       public partial class frm_people : Form
       {
            // This has to happen in the load event of the form, sticking in constructor for now, but this is bad practice.
            
            public frm_people()
            {
            List<People> people = new List<People>();
    
            People data = new Person("James", false, "Cardiff");
            
            // or
            People data1 = new Person { 
              Name = "James", 
              Disabled = false, 
              Hometown = "Cardiff"
            };
    
            people.Add(data);
            }
       }
    }
