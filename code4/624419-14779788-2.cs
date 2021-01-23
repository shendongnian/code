    public static void ConfigureMappings()
    {
      Mapper.CreateMap<TreeNodeDto, Taxonomy>()
      .AfterMap((s, d) =>
      {  
         //WCF service calls to get parent and children
         d.Children =  Mapper.Map<TreeNodeDto[], TreeNode[]>(client.GetTreeChildren(s)).ToList();
        foreach( var child in d.Children)
        {
           child.Parent = d;
        }
    }
