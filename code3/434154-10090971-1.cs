    public AttachmentRequestDto AddAttachmentToNote(Stream stream)
            {
                MultipartParser parser = new MultipartParser(stream);
                if(parser != null && parser.Success)
                {
                    foreach (var content in parser.MyContents)
                    {
                        // Observe your string here which is a serialized version of your file or the object being passed. Based on the string do the necessary action.
                        string str = Encoding.UTF8.GetString(content.Data);
    
                    }
                }
                
                return new AttachmentRequestDto();
            }
