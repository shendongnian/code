    public class YourEntityConfiguration : EntityTypeConfiguration<YourEntity>
    {
        public YourEntityConfiguration ()
        {
            ToTable("WhatEverYouLike"); // here you can do any magic to map this entity to a table, just make sure that your properties are mapped to the correct colums
            Property(entity => entity.Id).HasColumnName("YouColumnName");
            //and here you also have to do the other configurations
        }
    }
