    private static SpeechSynthesizer synth;
    public async static Task<SpeechSynthesizer> SpeechSynth(string dataToSpeak)
            {
                synth = new SpeechSynthesizer();
                IEnumerable<VoiceInformation> englishVoices = from voice in InstalledVoices.All
                                                              where voice.Language == "en-US"
                                                              && voice.Gender.Equals(VoiceGender.Female)
                                                              select voice;
                if (englishVoices.Count() > 0)
                {
                    synth.SetVoice(englishVoices.ElementAt(0));
                }
    
                await synth.SpeakTextAsync(dataToSpeak); 
    
                return synth;
            }  
      
        
    public static void CancelSpeech()
            {
                synth.CancelAll();
            }
