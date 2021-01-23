     public  class Department
    {
    private string departmentId;
    private string departmentName;
    private Hashtable doctors = new Hashtable();//Store doctors for 
                                                //each department
     public Hashtable Doctor  
    {
     get { return doctors; }
      }
     }
