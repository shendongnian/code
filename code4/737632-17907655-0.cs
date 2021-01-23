    for(int i = 0; i < PictureBoxArray.GetLength(0); i++) 
    {
        for(int j = 0; j < PictureBoxArray.GetLength(1); j++)
        {
            //attach handler
            PictureBoxArray[i,j].Click += pictureBox_Click;
        }
    }
    void pictureBox_Click(object sender, EventArgs e)
    {
       MyMethod();      
    }
    void parentForm_Click(object sender, EventArgs e)
    {
       MyMethod();       
    }
    private void MyMethod()
    {
       //method to be called
    }
    
