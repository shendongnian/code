    SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();
    recognitionEngine.SetInputToDefaultAudioDevice();
    recognitionEngine.SpeechRecognized += (s, args) =>
    {
        foreach (RecognizedWordUnit word in args.Result.Words)
        {
            Console.WriteLine(word.Text);
        }
    };
    recognitionEngine.LoadGrammar(new DictationGrammar());
