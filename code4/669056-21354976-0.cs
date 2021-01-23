    // required for SpeechSynthesizer
    using TranslatorService.Speech;
    namespace AppName
    {
        public partial class MainPage : PhoneApplicationPage
        {
            private void TextToSpeech_Play(object sender, EventArgs e)
            {
                SpeechSynthesizer speech = new SpeechSynthesizer(CLIENT_ID, CLIENT_SECRET);
                speech.SpeakAsync("This is a beautiful day!");
            }
        }
    }
