    MyClassMap : ...
    {
      HasMany(x => Entries)
        .KeyColumn("MyClsId")
        .Cascade.All()
        .Where("IsDeleted = 0"); // that will load only IsDeleted == false lazily
    }
