        private void init()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    (ctrl as Button).MouseHover += new EventHandler(Common_MouseHover);
                }
            }
        }
