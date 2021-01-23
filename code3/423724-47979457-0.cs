            /* var btn = sender as CardButton;*/
         if (e.Button == MouseButtons.Left)
                if (this.Selected == false) { 
                this.Selected = true;
                }
                else
                this.Selected = false;
            if (e.Button == MouseButtons.Right)
            {
                if (this.Selected == false)
                {
                    this.Selected = true;
                }
                else
                    this.Selected = false;
            }
            Draw();
        }
