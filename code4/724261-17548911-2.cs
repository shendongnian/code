    	for (int i = 1; i <= 4; i++)
        {
             if (i <= list.Count)
                { 
                  this.Controls["TextBox"+i.ToString()].Text = list[i-1];
                  this.Controls["TextBox"+i.ToString()].Enabled = True;
                 }
             else
                 {
                   this.Controls["TextBox"+i.ToString()].Enabled = False;
                 }                 
        }
