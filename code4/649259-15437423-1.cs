        string word = txtSelect.Text;
        string[] splt = word.Split(',');
        for (int x = 0; x < splt.Length; x++)
        {
           Control myControl1 = FindControl("ms" + splt[x]);
           if ( myControl1 != null )
             (ToolStripMenuItem)myControl1.Visible = true;
        }
