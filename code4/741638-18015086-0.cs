     private void btnAdd_Click(object sender, EventArgs e)
     {
        Students myStudent = new Students();
        ...
        ...
        // change the student photo to byte array e.g. 
        // public byte[] Photo {get;set;}
        myStudent.photo = imageToByteArray(Image.FromFile(openFileDialog1.FileName));
        ...
        ...
        // Insert New Record
        if (myStudent.AddStudent(myStudent))
        MessageBox.Show("Student Added Successfully");
     }
    
     // convert image to byte array
     public byte[] imageToByteArray(System.Drawing.Image imageIn)
     {
        MemoryStream ms = new MemoryStream();
        imageIn.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
        return  ms.ToArray();
     }
    
    //Byte array to photo
    public Image byteArrayToImage(byte[] byteArrayIn)
    {
         MemoryStream ms = new MemoryStream(byteArrayIn);
         Image returnImage = Image.FromStream(ms);
         return returnImage;
    }
