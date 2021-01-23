     private void c_CheckedChanged(object sender, EventArgs e)
        {
           if (((CheckBox)sender).Checked)
           {
              ((CheckBox)(this.Controls.Find("c1", false))[0]).Enabled = false;
           }
        }
