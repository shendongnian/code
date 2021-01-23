    public Operation Operation { get; private set; }
    private void rb_CheckedChanged(object sender, EventArgs e)
    {
        var rb = sender as RadioButton;
        if (rb.Checked)
        {
            this.Operation = (Operation)Enum.Parse(typeof(Operation), rb.Tag as string);
            ...
        }
    }
