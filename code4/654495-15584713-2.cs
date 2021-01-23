    void ShowPicture(int index)
    {
        Images[index].LoadBigImage();
        PictureBoxBig.image = Images[index].Big;
    }
    void ClosePicture(int index)
    {
        Images[index].UnloadImage();
    }
