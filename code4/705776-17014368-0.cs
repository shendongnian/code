    public static byte[] GetBytesFromBmp(Bitmap bmp)
            {
                //initialize quality array
                Int64[] qual = { 100L, 90L, 80L, 70L, 60L, 50L, 40L, 30L, 20L, 10L };
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                var myEncoder = Encoder.Quality;
                var encParameters = new EncoderParameters(1);
                int qualindex = 0;
    
                byte[] ret;
                do
                {
                    //generate for selected quality
                    var param = new EncoderParameter(myEncoder, qual[qualindex]);
                    qualindex++;
                    encParameters.Param[0] = param;
    
                    var str = new MemoryStream();
                    bmp.Save(str, jpgEncoder, encParameters);
                    ret = str.ToArray();
    
                } while (ret.Length > 7900 && qualindex < 8); //lower quality and check if the size doesn't exceeded SQL CE limitations
    
                return ret;
            } 
