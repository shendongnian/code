    public partial class AudioPlayer : System.Web.UI.Page
    {
        protected override void OnPreRender(EventArgs e)
        {
            Response.ContentType = "audio/wav";
            MemoryStream mstream = GetAudio(Session["captcha"] as string);
            mstream.Position = 0;            
            mstream.CopyTo(Response.OutputStream);
            Response.End();
        }
        public static MemoryStream GetAudio(string input)
        {
            MemoryStream mem = new MemoryStream();
            Thread t = new Thread(new ThreadStart(() =>
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();
                synth.Rate = -5;
                synth.SetOutputToWaveStream(mem);
                synth.Speak(input);
            }));
            t.Start();
            t.Join();
            return mem;
        }
    }
