    private void MediaButton_MouseDown(object sender, MouseEventArgs e) 
    { 
                this.Image = this.downImage; 
                this.Invalidate(); 
                this.Refresh(); 
     }
     
    private void MediaButton_MouseUp(object sender, MouseEventArgs e) 
    {
                this.Image = this.upImage; 
                this.Invalidate(); 
                this.Refresh(); 
    } 
