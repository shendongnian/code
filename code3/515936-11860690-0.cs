    public class Program
    {
       public int ID { get; set; }
       public string Name { get; set; }
       public virtual ProfessionalEmploymentRecord ProfessionalEmploymentRecord { get; set; }
    }
    
    public class Role
    {
       public int ID { get; set; }
       public string Name { get; set; }
       public virtual ProfessionalEmploymentRecord ProfessionalEmploymentRecord { get; set; }
    }
