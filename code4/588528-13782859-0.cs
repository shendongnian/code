    static ImageList _imageList;
    public static ImageList ImageList
    {
        get
        {
            if (_imageList == null)
            {
                _imageList = new ImageList();
                _imageList.Images.Add("Applications", Properties.Resources.Image_Applications);
                _imageList.Images.Add("Application", Properties.Resources.Image_Application);
            }
            return _imageList;
        }
    }
