    List<string> GetMyCheckboxes(ControlCollection coll, List<string> ids)
    {
        foreach (Control ctl in coll)
        {
            if (ctl.ID.StartsWith(ID_Prefix))
                ids.Add(ctl.ID.Substring(ID_Prefix.Length)); // only take the number
            if (ctl.Controls.Count > 0)
                ids = GetInputs(ctl.Controls, ids);
        }
        return ids;
    }
