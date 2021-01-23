        public class Place
        {
            ...
            
            public class PlaceMapping : EntityTypeConfiguration<Place>
            {
                public PlaceMapping()
                {
                    HasMany(m => m.Tags).WithMany();
                }
            }
        }
