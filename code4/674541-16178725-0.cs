     protected void Page_Load(object sender, EventArgs e)
        {
            PlayCaptchaSession();
        }
        private void PlayCaptchaSession()
        {
            object o = Session["captcha"];
            if (o != null)
            {
                HttpContext context = HttpContext.Current;
                if (context == null || context.Response == null)
                {
                    return;
                }
                //context.Response.AddHeader("content-disposition", "inline; filename=" + "captcha.wav");
                context.Response.AddHeader("content-transfer-encoding", "binary");
                context.Response.ContentType = "audio/wav";
                SoundGenerator soundGenerator = new SoundGenerator(o as string);
                MemoryStream sound = new MemoryStream();
                // Write the sound to the response stream 
                soundGenerator.Sound.Save(sound, SoundFormatEnum.Wav);
                sound.WriteTo(context.Response.OutputStream);
            }
        }
    }
