    [Export(typeof(PluginBase))]
    public PluginBase MyPlugin
    {
        get
        {
            if (someCondition)
            {
               return new FooPlugin();
            }
            else
            {
               return new BarPlugin();
            }
        }
    }
