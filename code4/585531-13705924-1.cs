    public class AttendanceConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            this.HasRequired(a => a.Employee)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.EmployeeID);
        }
    }
