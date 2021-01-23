    public ContentResult GetImage()
            {
                var content = new ContentResult();
                content.Content = "Image as String";
                content.ContentType = "image/jpg";
                return content;
            }
