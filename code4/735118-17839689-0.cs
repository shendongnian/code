    private void Form1_Load(object sender, EventArgs e)
    {
        _recognizer.SetInputToDefaultAudioDevice();
        _recognizer.LoadGrammar(new DictationGrammar());
        var grammarBuilder = new GrammarBuilder(
                  new Choices(
                  File.ReadAllLines(
                    @"C:\Users\Tahmid\Documents\Commands.txt")));
        grammarBuilder.Culture = new new System.Globalization.CultureInfo("en-GB");
        _recognizer.LoadGrammar(new Grammar(grammarBuilder));
        _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);
        _recognizer.RecognizeAsync(RecognizeMode.Multiple);
    } 
