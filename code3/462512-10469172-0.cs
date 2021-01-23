    public class ImageData
    {
        public bool HasData {get;set;}
        public byte[] Data {get; set;}
        public string ErrorMessage {get; set;}
    }
    ImageData imageData = GetPic();
    if (imageData.HasData)
    {
         myService.SendImage(imageData.Data);
    }
    else
    {
        // Error!
        _logger.Write("Could not get image: " + imageData.ErrorMessage);
    }
