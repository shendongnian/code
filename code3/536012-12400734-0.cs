    private SpeechRecognitionEngine rec;
    
    private void voice()     
    {
        rec = new SpeechRecognitionEngine();
        rec.SetInputToDefaultAudioDevice();
        Choices choice = new Choices("apple","Orange","Onion", "next");
        GrammarBuilder gr = new GrammarBuilder(choice);
        Grammar grammar = new Grammar(gr);
        rec.LoadGrammar(grammar);
        rec.SpeechRecognized += 
            new EventHandler<SpeechRecognizedEventArgs>(rec_SpeechRecogonized);
        rec.RecognizeAsync(RecognizeMode.Multiple);
    }
    
    private TextBox currentInput;
    void rec_SpeechRecogonized(object sender, SpeechRecognizedEventArgs e)
    {
        if (currentInput == null) currentInput = textBox1;
        foreach (RecognizedWordUnit word in e.Result.Words)
        {
             if (word.Text = "next") { currentInput = textBox2 }
             else { currentInput.Text = word.Text; }
        }
    }
