    public class Employee
    {
        public virtual string Name {get; set;}
    }
    
    public class GeneralStaff
    {
        public override string Name {get; set;}
    }
    
    class Program
    {
            static void Main(string[] args)
            {
                Employee emp = new GeneralStaff();
                emp.Name = "Abc Xyz";
                //---- More code follows----            
            }
    }
        
