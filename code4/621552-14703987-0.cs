    protected void IsEditable()
        {
            foreach (ChildForm f in MdiChildren)
            { 
                if (f.isEditable == true)
                {
                    f.SaveForm();
                    f.Close();
                }
            }
        }
