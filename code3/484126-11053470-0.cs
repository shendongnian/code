        public class SpeechRecognizer
        {
            public List<string> SpeechRecognized = new List<string>
            {
            };
            public void SaveRecognizedSpeech(string foundSpeech)
            {
                SpeechRecognized.Add(foundSpeech);
            }
        }
