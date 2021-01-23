    private SpeechSynthesizer synth = new SpeechSynthesizer();
    private IAsyncAction task;
    
    private void ButtonCancelSpeech(object sender, EventArgs eventArgs)
    {
        try
        { 
            //cancel the async task itself
            task.Cancel();
        }
        catch (TaskCanceledException)
        {
                
        }
        }
    
    private void BtnSpeech_Click(object sender, EventArgs e)
    {
        IEnumerable<VoiceInformation> voices = from voice in InstalledVoices.All
                                                         where voice.Language.Substring(0, 2).Equals(LanguageApp.GetLangage2Characters())
                                                         select voice;
        if (voices.ElementAt(0) != null)
        {
            // Set the voice as identified by the query.
            synth.SetVoice(voices.ElementAt(0));
    
            task = synth.SpeakTextAsync(_place.Description);
        }
    }
