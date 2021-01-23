        protected void Button1_Click(object sender, EventArgs e)
        {
            if(((Button)sender).BackColor != Color.Red)
            {((Button)sender).BackColor = Color.Yellow;}
        }
        protected void button7_Click(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control is Button && (Button)sender != control && ((Button)control).BackColor == Color.Yellow)
                {
                    ((Button)control).BackColor = Color.Red;
                }
            }
        }     
