    public PropertyMap()
    {
      Table("Property");
      Id(x => x.Id).GeneratedBy.Identity();
      Map(x => x.Title).Length(255).Not.Nullable();
      HasMany(x => x.Photos).KeyColumn("Id"); // you were already doing this
    }
    public PhotoMap()
     {
        Table("Photo");
        Id(x => x.Id).GeneratedBy.Identity();
        Map(x => x.Version);
        Map(x => x.ImageData).CustomSqlType("VARBINARY(MAX)").Length(160000);
        Map(x => x.ImageMimeType);
        References( x => x.Property ) // you'll need 'Property' in your class definition too
            .Column('PhotoId')
            .Cascade.All();
     }
