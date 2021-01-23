            string textTitle = tbxTitle.Text;
            string textSubtitle = tbxSubtitle.Text;
            string deviceUri = tbxUri.Text;
            string msg =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                "<wp:Notification xmlns:wp=\"WPNotification\">" +
                    "<wp:Toast>" +
                    "<wp:Text1>" + textTitle + "</wp:Text1>" +
                    "<wp:Text2>" + textSubtitle + "</wp:Text2>" +
                    "</wp:Toast>" +
                "</wp:Notification>";
            byte[] msgBytes = new UTF8Encoding().GetBytes(msg);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(channelUri);
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "text/xml";
            request.ContentLength = msg.Length;
            request.Headers["X-MessageID"] = Guid.NewGuid().ToString();
            request.Headers["X-WindowsPhone-Target"] = "toast";
            request.Headers["X-NotificationClass"] = "2";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(msgBytes, 0, msgBytes.Length);
            requestStream.Close();
