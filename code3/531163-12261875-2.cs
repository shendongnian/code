    public class EnrollTrainee
	{
		[Key]
		public int id { get; set; }
		public int TraineeID { get; set; }
		public virtual CreateUser Trainee { get; set; }
		public int TrainerID { get; set; }
		public virtual CreateUser Trainer { get; set; }
		public DateTime dt { get; set; }
	}
	internal class EnrollTraineeConfiguration:EntityTypeConfiguration<EnrollTrainee>
	{
		public EnrollTraineeConfiguration()
		{
			ToTable("EnrollTrainee");
			Property(c => c.dt).HasColumnName("dt");
			Property(c => c.TraineeID).HasColumnName("TraineeID");
			Property(c => c.TrainerID).HasColumnName("TrainerID");
			HasKey(c => c.id);
			HasRequired(c => c.Trainee).WithMany().HasForeignKey(c=>c.TraineeId);
			HasRequired(c => c.Trainer).WithMany().HasForeignKey(c => c.TrainerId);
		}
	}
    public class Context: DbContext
    {
         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
              modelBuilder.Configurations.Add(new EnrollTraineeConfiguration());
              ......
         }
         ....
    }
