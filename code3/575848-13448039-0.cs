    int numberOfImages = 10; // Replace 10 with number of your images
    for(int i=0; i<numberOfImages; i++)
    {
       using(Bitmap img = new Bitmap(string.Format(@"C:\Project\Images\Image{0}.jpg", i+1)))
       {
           DataGridView [2, i].Value = img;
       }    
    }
