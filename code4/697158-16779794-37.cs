    // Method of public class TestVoiceAsync : TtsAsyncActivity
    private async void GetEnginesAndLangsAsync()
    {
        _tts = new TextToSpeech(this, null);
        IList<TextToSpeech.EngineInfo> engines = _tts.Engines;
        try
        {
            _tts.Shutdown();
        }
        catch { /* don't care */ }
        foreach (TextToSpeech.EngineInfo ei in engines)
        {
            Log.Debug(TAG, "Trying to create TTS Engine: " + ei.Name);
            _tts = await CreateTtsAsync(this, ei.Name);
            // DISRUPTION 1 from Java code eliminated, we simply await TTS engine initialization here.
            if (_tts != null)
            {
                var el = new EngLang(ei);
                _allEngines.Add(el);
                Log.Debug(TAG, "Engine: " + ei.Name + " initialized correctly.");
                var intent = new Intent(TextToSpeech.Engine.ActionCheckTtsData);
                intent = intent.SetPackage(el.Ei.Name);
                Intent data = await StartActivityForResultAsync(intent, LANG_REQUEST);
                // DISTRUPTION 2 from Java code eliminated, we simply await until the result returns.
                try
                {
                    // don't care if lastData or voices comes out null, just catch exception and continue
                    IList<String> voices = data.GetStringArrayListExtra(TextToSpeech.Engine.ExtraAvailableVoices);
                    Log.Debug(TAG, "Listing voices for " + el.Name() + " (" + el.Label() + "):");
                    foreach (String s in voices)
                    {
                        el.AddVoice(s);
                        Log.Debug(TAG, "- " + s);
                    }
                }
                catch (Exception e)
                {
                    Log.Debug(TAG, "Engine " + el.Name() + " listing voices exception: " + e);
                }
                try
                {
                    _tts.Shutdown();
                }
                catch { /* don't care */ }
                _tts = null;
            }
        }
        // At this point we have all the data needed to initialize our language
        // and voice selector spinners, can complete the activity setup.
        ...
    }
