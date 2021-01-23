    Employee oEmployee1 = 
       new Employee{Name="Pini",ID="111", Age="30"};
 
    System.Web.Script.Serialization.JavaScriptSerializer oSerializer = 
         new System.Web.Script.Serialization.JavaScriptSerializer();
    string sJSON = oSerializer.Serialize(oEmployee1);
