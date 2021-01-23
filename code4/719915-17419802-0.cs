        Control ActiveControl = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
               if(c is TextBox)
               {
                c.GotFocus += (s, o) =>
                    {
                        this.ActiveControl = s as Control;
                    };
               }
            }
        }
