    var version = new EstimateVersion();
    //Code that inserts values into the object's properties
    Repository.Save(version);
    var template = new Template();
    //Code that inserts values into the object's properties
    template.EstimateVersion = version;
    Repository.Save(template);
