    Dictionary<string, string[]> brandsAndModels = new Dictionary<string, string[]>();
    public void Form_Load(object sender, EventArgs e)
    {
        brandsAndModels["Samsung"] = new string[] { "Galaxy S", "Galaxy SII", "Galaxy SIII" };
        brandsAndModels["HTC"] = new string[] { "Hero", "Desire HD" };
    }
