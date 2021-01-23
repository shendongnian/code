     private void Form1_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }
    
        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            
            if (!this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
            {
                this.Opacity = 0.5;
            }
        }
