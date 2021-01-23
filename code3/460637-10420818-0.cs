    public List<Whatever> Items
    {
        get
        {
            return MainCollection.Where( x => [someCondition] ).ToList();
        }
    }
