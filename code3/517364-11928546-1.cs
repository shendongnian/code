            SpeechSynthesizer _reader = new SpeechSynthesizer();
            _reader.SpeakStarted += ReaderSpeakStarted;
 
            _reader.SpeakAsync("Hello world A B C"); //asynchronize method!!! 
            _reader.SpeakAsync("Hello world B C D"); 
            _reader.SpeakAsync("Hello world C D E"); 
        }
        static void ReaderSpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            // now _speak started! 
            var spokenWord = GetTextFieldValue(e.Prompt);
            Console.WriteLine("_reader_SpeakStarted\t" + spokenWord);
            // string textContent=???? 
            //  updateGUI(textContent); 
        }
        private static string GetTextFieldValue(Prompt p)
        {
            var text = typeof(Prompt).GetField("_text", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(p);
            return (string)(text.GetType() == typeof(String) ? text : string.Empty);
        }
