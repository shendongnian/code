        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < panel1.Controls.Count; i++)
        {
            if (panel1.Controls[i].Controls.Count > 0)
            {
                //Iterate through the controls in the user control
                foreach(Control c in panel1.Controls[i].Controls)
                {
                }
            }
            else
            {
                //Handle the controls with no children
            }
        }
