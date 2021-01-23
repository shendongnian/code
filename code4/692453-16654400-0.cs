    var yourObject = new ObjectYouWishToControl();
    
    ...
    
    private void Button1_Click(object sender, MouseEventArgs e)
    {
        yourObject.Button1WasClicked = true;
    }
    
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (yourObject.Button1WasClicked)
        {
            // do your thing
        }
    }
