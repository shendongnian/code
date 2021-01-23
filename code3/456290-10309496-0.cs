    var fb = new FacebookClient(accessToken);
    string attachementPath = @"C:\image.jpg";
     
    using (var stream = File.OpenRead(attachementPath))
    {
        dynamic result = fb.Post("me/photos",
                                    new
                                        {
                                            message = "upload using Facebook C# SDK",
                                            file = new FacebookMediaStream
                                                    {
                                                        ContentType = "image/jpg",
                                                        FileName = Path.GetFileName(attachementPath)
                                                    }.SetValue(stream)
                                        });
    }
