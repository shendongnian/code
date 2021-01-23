    public static string UploadPhoto(string imageName, string albumID, string accesstoken, string photoComment = null, bool doNotPostStory = false)
    {
    	var fbAPI = new FacebookApp(accesstoken);
    	var p = new FacebookMediaObject {FileName = path};
    
    	p.SetValue( <<YOUR IMAGE GOES HERE AS byte[]>>);
    
    	p.ContentType = "multipart/form-data";
    
    	var param = new Dictionary<string, object> { {"attachment", p} };
    	if (!string.IsNullOrEmpty(photoComment))
    		param.Add("message", photoComment);
    
    	// http://stackoverflow.com/questions/7340949/is-it-possible-to-upload-a-photo-to-fanpage-album-without-publishing-it
    	// http://developers.facebook.com/blog/post/482/
    	if (doNotPostStory == true)
    	{
    		param.Add("no_story", "1");
    	}
    
    	var result = fbAPI.Post(string.Format("http://graph.facebook.com/{0}/photos", albumID), param);
    	return result.ToString();
    }
