        private void Rectangle1_MouseEnter(object sender, EventArgs e)
        {
            myForm.Height = Rectangle1.Height + Rectangle2.Height;
        }
        private void Rectangle1_MouseLeave(object sender, EventArgs e)
        {
            if (!myForm.Bounds.Contains(MousePosition))
            {
                myForm.Height = Rectangle1.Height;
            }
        }
 
