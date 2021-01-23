    public event EventHandler TextChanged;
    private void foo_TextChanged(object sender, EventArgs e)
    {
        if (this.TextChanged != null) { this.TextChanged(sender, e); }
    }
