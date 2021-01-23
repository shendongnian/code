    public Control FindControlDeep(Control parent, string id) 
    {
        Control result = parent.FindControl(id);
        if (result == null)
        {
            for (int iter = 0; iter < parent.Controls.Count; iter++)
            {
                result = FindControlDeep(parent.Controls[iter], id);
                if (result != null)
                    break;
            }
        }
        return result;
    }
