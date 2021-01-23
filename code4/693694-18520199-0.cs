    using (
          SpeechRecognitionEngine recognizer =
          new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US")))
    {
       DictationGrammar dg = new DictationGrammar();
       recognizer.LoadGrammar(dg);
       recognizer.RecognizeAsync();
    }
