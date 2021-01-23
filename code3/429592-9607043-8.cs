      foreach (TableCell Tc in GridView1.HeaderRow.Cells)
        {
            //if you are not getting value than find childcontrol of TabelCell.
            string sssb = Tc.Text;
            foreach (Control ctl in Tc.Controls)
            {
                //Child controls
                Label lb = ctl as Label;
                string s = lb.Text;
            }
        }
