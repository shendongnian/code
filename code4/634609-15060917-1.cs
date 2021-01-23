    public class Employee    
    {  
      public Int32 employeeId;    
      public String employeeFName;    
      public String employeeSName;         
      public string empGenderString;
      public string empContactNo;    
      public DateTime empDOB;    
      public string empAddress;    
      public Int16 accessLevel;    
      private string pass;    
    public Gender empGender
    {
        get { return this.empGenderString == "Male" ?
                     Gender.Male:
                     Gender.Female;
            }
    public String Pass
    {
        get { return this.pass; }
        set { this.pass = value; }
    }
}
