    string[] _PicList = null;
    int current = 0;
    _PicList = System.IO.Directory.GetFiles("C:\\Documents and Settings\\Hasanka\\
                                                   Desktop\\deaktop21052012\\UPEKA","*.jpg"); 
    // "*.jpg" will select all 
    //pictures in your folder
    String str= _PicList[current];
    DisplayPicture(str);
    private void DisplayPicture(string str)
    {
        //throw new NotImplementedException();
        BitmapImage bi = new BitmapImage(new Uri(str));
        imagePicutre.Source = bi; // im using Image in WPF 
        //if u r using windows form application it must be a PictureBox i think.
        label1.Content = str;
    }
