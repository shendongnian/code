    private void SetImage(int day)
    {
        if (day >= 1 && day <= 7)
        {
            myImage.ImageUrl = @"~\ImageOne.jpeg";
        }
        else if (day >= 8 && day <= 14)
        {
            myImage.ImageUrl = @"~\ImageTwo.jpeg";
        }
        else if (day >= 15 && day <= 21)
        {
            myImage.ImageUrl = @"~\ImageThree.jpeg";
        }
        else if (day >= 22 && day <= 31)
        {
            myImage.ImageUrl = @"~\ImageFour.jpeg";
        }
        else
        {
            throw new Exception("Invalid Day");
        }
    }
