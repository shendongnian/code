    private string getRadioValue(ControlCollection clts, string groupName)
    {
        var ret = "";
        foreach (Control ctl in clts)
        {
            if (ctl.Controls.Count != 0)
            {
                ret = getRadioValue(ctl.Controls, groupName);
            }
            if (!string.IsNullOrEmpty(ret)) {
              return ret;
            }
            var rb = ctl as RadioButton;
            if (rb != null && rb.GroupName == groupName && rb.Checked)
                    return = rb.Attributes["Value"];
            }
        }
        return ret;
    }
