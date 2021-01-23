    HasMany(x => x.Commits)
        .Cascade.All()
        .KeyColumn("fRC_Project_ID")
        .Inverse();
    // change Map(x => x.ProjectID, "fRC_Project_ID").Not.Nullable(); to
    References(x => x.Project, "fRC_Project_ID").Not.Nullable(); // where Project property is of type Project
