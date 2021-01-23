    private void button1_Click(object sender, EventArgs e)
    {
        label1.Text = (from c in GetAll(this, typeof(CheckBox))
                        where (c as CheckBox).Checked
                        select c).Count().ToString();                    
    }
    // credits go to @PsychoCoder for this part
    public IEnumerable<Control> GetAll(Control control, Type type)
    {
        var controls = control.Controls.Cast<Control>();
        return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                    .Concat(controls)
                                    .Where(c => c.GetType() == type);
    }
