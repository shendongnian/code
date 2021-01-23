    public void Base64ToResponse(string base64String)
    {
        Response.ContentType = "text/png"; //or whatever...
        byte[] imageBytes = Convert.FromBase64String(base64String);
        Response.OutputStream(imageBytes, 0, imageBytes.Length);
    }
