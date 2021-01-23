        public Task<FileStreamResult> Speak(string text)
        {
            return Task.Factory.StartNew(() =>
            {
                using (var synthesizer = new SpeechSynthesizer())
                {
                    var ms = new MemoryStream();
                    synthesizer.SetOutputToWaveStream(ms);
                    synthesizer.Speak(text);
                    ms.Position = 0;
                    return new FileStreamResult(ms, "audio/wav");
                }
            });
        }
