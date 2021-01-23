    public override void Initialize(string name, NameValueCollection config)
    {
        config["connectionString"] = ... whatever ...;
        base.Initialize(name, config);
    }
