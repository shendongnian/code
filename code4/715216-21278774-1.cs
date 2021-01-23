            dynamic argumentContent = new ExpandoObject();
            argumentContent.message = imageDesc;
            if (!string.IsNullOrEmpty(imageUrl))
                argumentContent.url = imageUrl;
            else
                argumentContent.source = new FacebookMediaObject
                {
                    ContentType = "image/jpeg",
                    FileName = FormatUploadPictureFileName()
                }.SetValue(imageBytes);
            FacebookClient fbClient = new FacebookClient(accessToken);
            fbClient.PostTaskAsync("me/photos", argumentContent);
            fbClient.PostCompleted += (postContent, Ex) =>
            {});
