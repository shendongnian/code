    // Assuming this is inside the form where the pictures boxes are hosted
    for (int i = 0; i < 30; i++){
        FieldInfo field = GetType().GetField("pictureBox_D"+i, flags);
        PictureBox pictureBox = (PictureBox)field.GetValue(this);
        if (ReceivedDataTextBox.Text[i].ToString()=="1") 
            pictureBox.Image= new Bitmap(@"Pictures\\green.png");
        else 
            pictureBox.Image= new Bitmap(@"Pictures\\red.png");
    }
