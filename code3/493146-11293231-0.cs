        private KinectAudioSource source;
        private SpeechRecognitionEngine sre;
        private Stream stream;
    private void CaptureAudio()
            {
        
                this.source = KinectSensor.KinectSensors[0].AudioSource;
                this.source.AutomaticGainControlEnabled = false;
                this.source.EchoCancellationMode = EchoCancellationMode.CancellationOnly;
                this.source.BeamAngleMode = BeamAngleMode.Adaptive;
            RecognizerInfo info = SpeechRecognitionEngine.InstalledRecognizers()
                .Where(r => r.Culture.TwoLetterISOLanguageName.Equals("en"))
                .FirstOrDefault();
            if (info == null) { return; }
            this.sre = new SpeechRecognitionEngine(info.Id);
            if(!isInitialized) CreateDefaultGrammars();
            sre.LoadGrammar(CreateGrammars()); //Important step
            this.sre.SpeechRecognized +=
                new EventHandler<SpeechRecognizedEventArgs>
                    (sre_SpeechRecognized);
            this.sre.SpeechHypothesized +=
                new EventHandler<SpeechHypothesizedEventArgs>
                    (sre_SpeechHypothesized);
            this.stream = this.source.Start();
            this.sre.SetInputToAudioStream(this.stream, new SpeechAudioFormatInfo(
                EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
            this.sre.RecognizeAsync(RecognizeMode.Multiple);
        }
