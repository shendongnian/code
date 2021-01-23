    {
        recognitionEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
    }
    //this method is static because I called it from a console main method. It can be changed.
    static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
         Console.WriteLine(e.Result.Text);
    }
