    // Create a Grammar for recognizing numeric digits.
    Grammar digitsGrammar = CreateDigitsGrammar();
    digitsGrammar.Name = "Digits Grammar";
    digitsGrammar.Priority = 2;
    digitsGrammar.Weight = 0.6f;
    // Create a Grammar for recognizing fractions.
    Grammar fractionsGrammar = CreateFractionsGrammar();
    fractionsGrammar.Name = "Fractions Grammar";
    fractionsGrammar.Priority = 1;
    fractionsGrammar.Weight = 1f;
    // Create an in-process speech recognizer.
    SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
    recognizer.SpeechRecognized +=new EventHandler<SpeechRecognizedEventArgs>(
    recognizer_SpeechRecognized);
    // Load the digits and fractions Grammar objects.
     recognizer.LoadGrammar(digitsGrammar);
     recognizer.LoadGrammar(fractionsGrammar);
     // Start recognition.
     recognizer.SetInputToDefaultAudioDevice();
     recognizer.RecognizeAsync(RecognizeMode.Multiple);
 
