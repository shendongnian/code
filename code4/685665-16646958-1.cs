    [OperationContract]
    [WebInvoke(Method = "POST",
            UriTemplate = "UploadFBPost",
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
    void UploadFBPost(Stream stream);
     public void UploadFBPost(Stream stream)
    {
        MultipartParser parser = new MultipartParser(stream);
        // Saves post data in database
        if (parser.Success)
        {
            string fileName = null, userId = null, postText = null, postType = null, accessToken = null;
            DateTime scheduleDate = DateTime.Now;
            string[] groupIds = null;
            int postId = 0;
            // Other contents
            foreach (MyContent content in parser.MyContents)
            {
                switch (content.PropertyName)
                {
                    case "scheduleDate":
                        if (string.IsNullOrEmpty(content.StringData.Trim()))
                            scheduleDate = DateTime.Now;
                        else
                            scheduleDate = DateTime.ParseExact(content.StringData.Trim(), "M-d-yyyy H:m:s", CultureInfo.InvariantCulture);
                        break;
                    case "fileName":
                        fileName = content.StringData.Trim();
                        break;
                    case "userId":
                        userId = content.StringData.Trim();
                        break;
                    case "postText":
                        postText = content.StringData.Trim();
                        break;
                    case "accessToken":
                        accessToken = content.StringData.Trim();
                        break;
                    
                    case "groupIds":
                        groupIds = content.StringData.Trim().Split(new char[] { ',' });
                        break;
                    case "postType":
                        postType = content.StringData.Trim();
                        break;
                    case "postId":
                        postId = Convert.ToInt32(content.StringData.Trim());
                        break;
                }
            }
            string videoFile = null, imageFile = null;
            if (parser.FileContents != null)
            {
                string filePath = GetUniqueUploadFileName(parser.Filename);
                File.WriteAllBytes(filePath, parser.FileContents);
                if (postType == "photo")
                    imageFile = Path.GetFileName(filePath); 
                else 
                    videoFile = Path.GetFileName(filePath); 
            }
        }
    }
