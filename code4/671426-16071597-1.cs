    foreach (KeyValuePair<Guid, string> r in roles)
    {
        CheckBox chk = new CheckBox();
        chk.ID = r.Value;
        chk.Text = r.Value;
        if(User.IsInRole(r.Value))
           chk.Checked = true;
        rolepanel.Controls.Add(chk);
    }
