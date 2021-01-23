        static void Main(string[] args)
        {
            SpeechSynthesizer _reader = new SpeechSynthesizer();
            _reader.SpeakStarted += ReaderSpeakStarted;
            _spokenWords = "Hello world A B C";
            _reader.SpeakAsync(_spokenWords); //asynchronize method!!! 
   
        }
        static void ReaderSpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            // now _speak started! 
            Console.WriteLine("_reader_SpeakStarted\t" + _spokenWords);
            // string textContent=???? 
            //  updateGUI(textContent); 
