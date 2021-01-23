    [WebMethod]
    public static string GetNextImage()
    {
      //
      // ... this is your code
      //
      RollingScreenBAL bal = new RollingScreenBAL();
      DetailsForSlideShow[] details = bal.GetDetailsForSlideShow(username);
      //Someway get next image you need to display
      //So I assume you get 1 record only (from DB?)
      DetailsForSlideShow detail = details[0];
      //Last you can save last sent image name or index as per user...
      //I.e. you could use a Session variable, or move also this logic
      //to client side
      [...]
      //Send back to jquery call the image url
      return ResolveUrl(detail.GraphUrl);
    }
