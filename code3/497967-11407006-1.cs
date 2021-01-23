    Dictionary<string, bool> state = new Dictionary<string, bool>();
    var checkBoxes = Controls.OfType<CheckBox>();
    foreach (var chk in checkBoxes)
    {
        if (!state.ContainsKey(chk.Name))
        {
            state.Add(chk.Name, chk.Checked);
        }
        else 
        {
            state[chk.Name] = chk.Checked;
        }
    }
