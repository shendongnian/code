            string webRootPath = _hostingEnvironment.WebRootPath;
            string fullPath = webRootPath + "/uploads/user-manual/file.pdf";
            string fullPaths = webRootPath + "/uploads/user-manual";
            using (var library = DocLib.Instance)
            {
                using (var docReader = library.GetDocReader(fullPath, 1080, 1920))
                {
                    for (int i = 1; i < docReader.GetPageCount(); i++)
                    {
                        using (var pageReader = docReader.GetPageReader(i))
                        {
                            var bytes = EmailTemplates.GetModifiedImage(pageReader);
                            System.IO.File.WriteAllBytes(fullPaths+"/page_image_" +i+".png", bytes);
                        }
                    }
                }
            }
