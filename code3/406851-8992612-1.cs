    public string Choices { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] choices = new string[] { "'Choice 1'", "'Choice 2'", "'Choice 3'" };
        Choices = String.Join(",", choices);
    }
