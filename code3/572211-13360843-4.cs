    class MyNewConfigurationType : EntityTypeConfiguration<Arc>
     {
        public MyNewConfigurationType()
        {
            Ignore<Angle>(y => y.start);
            Ignore<Angle>(y => y.end);
            Property<float>(x => x.start.Degrees).HasColumnName("myStartDegrees");
            Property<float>(x => x.end.Degrees).HasColumnName("MyEndDegrees");
        }
    }
