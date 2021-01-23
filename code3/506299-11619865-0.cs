    static bool HasErrors { get; set; }
    void HandleErrorEvent(object sender, EventArgs e)
    {
        HasErrors = true;
        // ... your logic here
    }
