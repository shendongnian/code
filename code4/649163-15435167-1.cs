    var newProject = new Project();
    // set other properties from posted model first then...
 
    newProject.Themes = model.ThemeIds.Select(x=> db.Themes.Find(x));
    db.Projects.Add(newProject);
    db.SaveChanges();
