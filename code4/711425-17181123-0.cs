    public class Department
    {
      [Key]
      public int Id { get; set; }
    
      public virtual ICollection<Function> Functions { get; set; }
    
      public virtual ICollection<DepartmentDocument> DepartmentDocuments { get; set; }
    }
    public class DepartmentDocument
    {
      [Key]
      public int Id { get; set; }
    
      [ForeignKey("Department")]
      public int DeptId { get; set; }
    
      [ForeignKey("Document")]
      public int DocId { get; set; }
    
      public virtual Department Department { get; set; }
    
      public virtual Document Document { get; set; }
    }
    public class Document
    {
      [Key]
      public int Id { get; set; }
    
      public virtual DepartmentDocument DepartmentDocument { get; set; }
    
      public virtual FunctionDocument FunctionDocument { get; set; }
    }
