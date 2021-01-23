    private void Checkbox_CheckedChanged(object sender, EventArgs e)
    {
        // this will use all checkboxes on Form
        string str = Controls.OfType<CheckBox>()
                             .Where(ch => ch.Checked)
                             .Aggregate(new StringBuilder(),
                                        (sb, ch) => sb.Append(ch.Name),
                                        sb => sb.ToString());
        // use string
    }
