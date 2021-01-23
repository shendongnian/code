    private static bool ConvertWordToTiff(string inputFilePath, string outputFilePath)
        {
            try
            {
                Document doc = new Document(inputFilePath);
                for (int i = 0; i < doc.PageCount; i++)
                {
                    ImageSaveOptions options = new ImageSaveOptions(SaveFormat.Tiff);
                    options.PageIndex = i;
                    options.PageCount = 1;
                    options.TiffCompression = TiffCompression.Lzw;
                    options.Resolution = 200;
                    options.ImageColorMode = ImageColorMode.BlackAndWhite;
                    var extension = Path.GetExtension(outputFilePath);
                    var pageNum = String.Format("-{0:000}", (i+1));
                    var outputPageFilePath = outputFilePath.Replace(extension, pageNum + extension);
                    doc.Save(outputPageFilePath, options);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }
