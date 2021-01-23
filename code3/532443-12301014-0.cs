    public bool IsSpoon(out Spoon sp) 
    {
        sp = Tools.GetAllItems().SelectMany(t => t.AllSpoons)
                                .FirstOrDefault(x => x.Label == this.Label);
        return sp != null;
    }
