    private static readonly AutoResetEvent Event1 = new AutoResetEvent(false);
    // Creates TTS object and waits until it's initialized. Returns initialized object,
    // or null if error.    private async Task<TextToSpeech> CreateTtsAsync(String engName)
    {
        var ttsInit = new TtsInit();
        Event1.Reset();
        var tts = new TextToSpeech(this, ttsInit, engName);
        await Task.Run(delegate { Event1.WaitOne(); });
        if (ttsInit.LastStatus != OperationResult.Success)
        {
            Log.Debug(TAG, "Engine: " + engName + " failed to initialize.");
            return null;
        }
        return tts;
    }
    private class TtsInit : Object, TextToSpeech.IOnInitListener
    {
        public OperationResult LastStatus { get; private set; }
        void TextToSpeech.IOnInitListener.OnInit(OperationResult status)
        {
            LastStatus = status;
            Event1.Set();
        }
    }
