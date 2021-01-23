    void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == speechSlide.Scenes[speechSlide.currentslide].speechCue)
            {
                rec.UnloadAllGrammars();
                ScreenSettings.NextSlide(speechSlide);
                try
                {
                    rec.LoadGrammar(GetGrammar());
                }
                catch
                {
                    rec.RecognizeAsyncCancel();
                }
            }
        }
