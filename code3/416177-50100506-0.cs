    GoogleCredential credentials =
        GoogleCredential.FromFile(Path.Combine(Program.AppPath, "jhabjan-test-47a56894d458.json"));
    
    TextToSpeechClient client = TextToSpeechClient.Create(credentials);
    
    SynthesizeSpeechResponse response = client.SynthesizeSpeech(
        new SynthesisInput()
        {
            Text = "Google Cloud Text-to-Speech enables developers to synthesize natural-sounding speech with 32 voices"
        },
        new VoiceSelectionParams()
        {
            LanguageCode = "en-US",
            Name = "en-US-Wavenet-C"
        },
        new AudioConfig()
        {
            AudioEncoding = AudioEncoding.Mp3
        }
    );
    
    string speechFile = Path.Combine(Directory.GetCurrentDirectory(), "sample.mp3");
    
    File.WriteAllBytes(speechFile, response.AudioContent);
