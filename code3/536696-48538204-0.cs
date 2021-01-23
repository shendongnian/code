    using System.Drawing.Imaging;
    using System.Drawing;
    
    public partial class Default3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VaryQualityLevel();
        }
        private void VaryQualityLevel()
        {
            Bitmap bmp1 = new Bitmap(Server.MapPath("test2.png"));
            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            System.Drawing.Imaging.Encoder myEncoder =System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(Server.MapPath("~/Images/1.jpg"), jgpEncoder, myEncoderParameters);
            //myEncoderParameter = new EncoderParameter(myEncoder, 75L);
            //myEncoderParameters.Param[0] = myEncoderParameter;
            //bmp1.Save(Server.MapPath("~/Images/2.jpg"), jgpEncoder, myEncoderParameters);
      
        }
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
    
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
