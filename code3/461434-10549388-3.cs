    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lesson>().ToTable("Lessons");
        modelBuilder.Entity<RecurringLesson>().ToTable("RecurringLessons");
        modelBuilder.Entity<PrivateLesson>().ToTable("PrivateLessons");
        modelBuilder.Entity<MakeUpLesson>().ToTable("PrivateMakeUpLessons");
    
        //modelBuilder.Entity<Cancellation>()
        //    .HasOptional(x => x.MakeUpLesson)
        //    .WithRequired(x => x.Cancellation);
    
        base.OnModelCreating(modelBuilder);
    }
