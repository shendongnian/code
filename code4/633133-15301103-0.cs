    using (CertsModelContainer db = new CertsModelContainer())
    {
        ((IObjectContextAdapter)db).ObjectStateManager.ObjectStateManagerChanged += (sender, e) =>
        {
            Console.WriteLine(string.Format(
                "ObjectStateManager.ObjectStateManagerChanged | Action: {0}, Object: {1}",
                e.Action,
                e.Element));
        };
    }
