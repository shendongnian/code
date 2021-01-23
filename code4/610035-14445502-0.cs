    AutoMap.AssemblyOf<Role>().Override<Role>(map =>
    {
        map.Id(x => x.Id, "RoleName")
            .CustomType<int>()
            .GeneratedBy.Identity()
            .UnsavedValue("0");
    });
