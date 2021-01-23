    private void BuildControlIDListRecursive(ControlCollection controls, List<string> ids)
    {
        foreach (Control c in controls)
        {
            ids.Add(string.Format("{0} : {2}", c.ID, c.UniqueID));
            BuildControlIDListRecursive(c.Controls, ids);
        }
    }
