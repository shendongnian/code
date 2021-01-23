    ResourceManager rm =
        new ResourceManager("ExampleAppData", typeof(ExampleApp).Assembly);
    String errorImageBase64 = rm.GetString("ErrorImageBase64");
    // the image you get from your request
    String resultImageBase64 = GetProfileImageBase64();
    
    Image missingProfile;
    if(resultImageBase64.Equals(errorImageBase64))
    {
        missingProfile = ImageFromBase64String(rm.GetString("MissingProfileBase64"));
    }
    else
    {
        missingProfile = ImageFromBase64String(resultImageBase64);
    }
