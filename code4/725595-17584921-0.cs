        if (e.CommandName == "Cancel")
        {
            gvWorkhours.EditIndex = -1;
            populateGrid(); 
            UpdatePanel1.Update();   // whatever the name of the UpdatePanel is
        }
