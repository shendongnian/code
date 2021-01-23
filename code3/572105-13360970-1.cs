    class CustomButton : Button
    {    
        CustomButton()
        {
            this.Resize += new System.EventHandler(buttonOne.CustomButton_Resize);
        }
    	void CustomButton_Resize( object sender, EventArgs e )
        {
           if ( this.BackgroundImage == null )
    	      return;
           var pic = new Bitmap( this.BackgroundImage, this.Width, this.Height );
    	   this.BackgroundImage = pic;          
    	}
    }
