    protected void rblChangeState_SelectedIndexChanged(object sender, EventArgs e)
    {
        Type t = pwr.GetType();
        PropertyInfo viewSetter = t.GetProperty("CurrentView", BindingFlags.Default | BindingFlags.NonPublic | BindingFlags.Instance);
        viewSetter.SetValue(pwr, Convert.ToInt32(rblChangeState.SelectedValue), null);
    }
