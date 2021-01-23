    public void OnSpeechRecognition(int StreamNumber, object StreamPosition, SpeechRecognitionType RecognitionType, ISpeechRecoResult Result)
    {
        int NUM_OF_ALTERNATES = 5; // Number of alternates sentences to be read
        string recognizedSentence = Result.PhraseInfo.GetText(0, -1, true);
    
        // Get alternate sentences
        int elementCount = Result.PhraseInfo.Elements.Count();
        for (int i = 0; i < elementCount; ++i)
        {
              ISpeechPhraseAlternates phraseAlternates = Result.Alternates(NUM_OF_ALTERNATES, i, 1);
        }
    }
