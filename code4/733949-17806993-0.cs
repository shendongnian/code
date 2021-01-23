    using(imgOut = new Bitmap((int)(x * factor), (int)(y * factor)))
    {
        using(var g = Graphics.FromImage(imgOut))
        {
            //rest of code...
        }
    }
