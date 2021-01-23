    public FileContentResult Image()
    {
       //Get the Byte Array for your image
       byte[] image = FilesBLL.GetImage();
       //Return a jpg
       //Note the second parameter is the files mime type
       return File(image, "image/jpeg");
    }
