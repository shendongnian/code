    var list = GetYourMainList(); 
    var renderableEntities = list.Where(item => item.IsRenderable); 
    var nonrenderableEntities = list.Where(item => !item.IsRenderable); 
    // work with the queries
    foreach (var item in renderableEntities)
    {
        // do whatever
    }
