    ...
    RecognizerInfo recognizerInfo = null;
    
    foreach (RecognizerInfo ri in SpeechRecognitionEngine.InstalledRecognizers())
    {
       if ((ri.Culture.TwoLetterISOLanguageName.Equals("en")) && (recognizerInfo == null))
       {
          recognizerInfo = ri;
          break;
       }
    
    }
                    
    SpeechRecognitionEngine SpeachRecognition = new SpeechRecognitionEngine(recognizerInfo);
    GrammarBuilder gb = new GrammarBuilder(startLiserninFraze);
    gb.Culture = recognizerInfo.Culture;
    grammar = new Grammar(gb);
    SpeachRecognition.RequestRecognizerUpdate();
    SpeachRecognition.LoadGrammar(grammar);
    SpeachRecognition.SpeechRecognized += SpeachRecognition_SpeechRecognized;
    SpeachRecognition.SetInputToDefaultAudioDevice();
    SpeachRecognition.RecognizeAsync(RecognizeMode.Multiple);
    ...
