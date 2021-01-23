    private async void GetEnginesAndLangsAsync()
    {
        _tts = new TextToSpeech(this, null);
	 // Get the list of available TTS engines
        IList<TextToSpeech.EngineInfo> engines = _tts.Engines;
        try
        {
            _tts.Shutdown();
        }
        catch {}
        foreach (TextToSpeech.EngineInfo ei in engines)
        {
            Log.Debug(TAG, "Trying to create TTS Engine: " + ei.Name);
            _tts = await CreateTtsAsync(ei.Name);
            // DISRUPTION 1 at this point is gone, C# continues when _tts is initialized
            if (_tts != null)
            {
                var el = new EngLang(ei);
                _allEngines.Add(el);
                var intent = new Intent(TextToSpeech.Engine.ActionCheckTtsData);
                intent = intent.SetPackage(el.Ei.Name);
                await StartActivityForResultAsync(intent, LANG_REQUEST);
                // DISRUPTION 2 at this point is gone as well!
                try
                {
                    // don't care if lastData or voices comes out null, just catch exception and continue
                    IList<String> voices = _lastData.GetStringArrayListExtra(TextToSpeech.Engine.ExtraAvailableVoices);
                    foreach (String s in voices)
                    {
                        el.AddVoice(s);
                    }
                }
                catch {}
                try
                {
                    _tts.Shutdown();
                }
                catch {}
                _tts = null;
            }
        }
        // At this point we have all the data needed to initialize our language
        // and voice selector spinners, can complete the activity setup.
        ...
    }
