    PictureBox[] txtTeamNames;
    void YourMethod()
    {
        Image myImage = Image.FromFile("image/Untitled6.png"); 
        txtTeamNames = new PictureBox[5];        
        //The same as your code
    }   
    void clcikeventhandle(object sender, EventArgs e)
    {          
        int index = txtTeamNames.IndexOf(sender As PictureBox);
    }
