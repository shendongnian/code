      ToolStripItem fs = new ToolStripMenuItem();
      fs.Text = c.ToString();
      fs.ForeColor = System.Drawing.Color.FromKnownColor(c);
      fs.BackColor = System.Drawing.Color.FromKnownColor(c);
      fs.Click += ChangeTextColor;
    
      toolStripDropDownButtonColor.DropDownItems.Add(fs);
