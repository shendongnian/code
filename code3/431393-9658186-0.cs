    public class Department 
    {
      private readonly List<Employee> _employees = new List<Employee>();
    
      public int Id { get; set; }     
      public string Name { get; set; }     
      public List<Employee> employees { get { return this._employees; }}       
    } 
