    internal class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(f => f.Id);
    
            HasRequired(e => e.Nationality)
              .WithMany()
              .Map(c => c.MapKey("NationalityId"));
    
            ToTable("Employees");
        }
    }
