        Using this object we serialize and deserialize  objects in C#. Here is a quick sample:
    
    A simple Employee object:
    
    public class Employee
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string ID { get; set; }   
    }
     
    Adding some instances of them to a List:
    
    Employee oEmployee1 = 
           new Employee{Name="Pini",ID="111", Age="30"};
    
    Employee oEmployee2 = 
          new Employee { Name = "Yaniv", ID = "Cohen", Age = "31" };
    Employee oEmployee3 = 
            new Employee { Name = "Yoni", ID = "Biton", Age = "20" };
    
    List<Employee> oList = new List<Employee>() 
    { oEmployee1, oEmployee2, oEmployee3 };
     
    Serializing then:
    
    System.Web.Script.Serialization.JavaScriptSerializer oSerializer = 
             new System.Web.Script.Serialization.JavaScriptSerializer();
    string sJSON = oSerializer.Serialize(oList);
    And here is the output:
    
    [{"Name":"Pini","Age":"30","ID":"111"},
    {"Name":"Yaniv","Age":"31","ID":"Cohen"},
    {"Name":"Yoni","Age":"20","ID":"Biton"}]
     
