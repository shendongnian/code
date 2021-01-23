    public bool AllAreChecked
    {
        return uc.Controls.OfType<CheckBox>().All(x => x.Checked);
    }
    public bool NumberChecked
    {
        return uc.Controls.OfType<CheckBox>().Count(x => x.Checked);
    }
