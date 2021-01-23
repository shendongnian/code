    private List<Module> modules;
    
    public void AddModule(Module add)
    {
        modules.Add(add);
    }
    
    // this one should be generic too
    public List<Module> Modules
    {
        get { return modules; }
    }
