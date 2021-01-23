    Project project = new Project(xmlFile2);
    XElement find = null;
    ItemGroup item = project.ItemGroup.FirstOrDefault(i =>
        (find = i.Build.Find(x => x.Get("Include", string.Empty) == "myfile.cs")) != null);
    if (null != find)
    {
        XElement not = new XElement(find.Name.Namespace + "NotInBuild");
        not.Set("Include", "myfile.cs", true);
        foreach (var child in find.Elements().ToArray())
            not.Add(child);
        find.Remove();
        ItemGroup notGroup = project.ItemGroup.FirstOrDefault(i => i.NotInBuild.Count > 0);
        notGroup.NotInBuild.Add(not);
    }
