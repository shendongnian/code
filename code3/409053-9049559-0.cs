         //MyparentControl is the parent control of myTable
         //so assuming 0 is the index of "myTable" 
         for (int h = 0; h < MyparentControl.Controls[0].Controls.Count; h++)
            {
                MyparentControl.Controls[0].Controls[h].Enabled = true;
            }
