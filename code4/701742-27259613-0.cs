    SpeechSynthesizer synt = new SpeechSynthesizer();
    IReadOnlyCollection<InstalledVoice> InstalledVoices = synt.GetInstalledVoices();
    InstalledVoice InstalledVoice = InstalledVoices.First();
    synt.SelectVoice(InstalledVoice.VoiceInfo.Name);
    synt.Speak("This is how you select an installed voice");
