    // Create a new SpeechRecognitionEngine instance.
          SpeechRecognizer recognizer = new SpeechRecognizer();
    
          // Create a simple grammar that recognizes "red", "green", or "blue".
          Choices colors = new Choices();
          colors.Add(new string[] { "red", "green", "blue" });
    
          // Create a GrammarBuilder object and append the Choices object.
          GrammarBuilder gb = new GrammarBuilder();
          gb.Append(colors);
    
          // Create the Grammar instance and load it into the speech recognition engine.
          Grammar g = new Grammar(gb);
          recognizer.LoadGrammar(g);
    
          // Register a handler for the SpeechRecognized event.
          recognizer.SpeechRecognized +=
            new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
        }
    
        // Create a simple handler for the SpeechRecognized event.
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
          MessageBox.Show("Speech recognized: " + e.Result.Text);
        }
