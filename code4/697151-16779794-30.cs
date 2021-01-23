    // Base class for an activity to create an initialized TextToSpeech object anynchroneously,
    // and starting intents for result anynchroneously, awaiting their result. Could be used for
    // other purposes too, remove TTS stuff if you only need StartActivityForResultAsync() 
    public class TtsAsyncActivity : Activity, TextToSpeech.IOnInitListener
    {
        private int _requestWanted = 0;
        private Intent _lastData = null;
        private OperationResult _lastStatus;
        private readonly AutoResetEvent _event1 = new AutoResetEvent(false);
        protected const String TAG = "TtsSetup";
        // Creates TTS object and waits until it's initialized. Returns initialized object,
        // or null if error.
        protected async Task<TextToSpeech> CreateTtsAsync(Context context, String engName)
        {
            _lastStatus = OperationResult.Error;
            var tts = new TextToSpeech(context, this, engName);
            await Task.Run(delegate { _event1.WaitOne(); });
            if (_lastStatus != OperationResult.Success)
            {
                Log.Debug(TAG, "Engine: " + engName + " failed to initialize.");
                return null;
            }
            return tts;
        }
        // Starts activity for results and waits for this result. Calling function may
        // inspect _lastData private member to get this result, or null if any error.
        // For sure, it could be written better to avoid class-wide _lastData member...
        protected async Task<Intent> StartActivityForResultAsync(Intent intent, int requestCode)
        {
            try
            {
                _lastData = null;
                _requestWanted = requestCode;
                StartActivityForResult(intent, requestCode);
                // possible exceptions: ActivityNotFoundException, also got SecurityException from com.turboled
                await Task.Run(delegate { _event1.WaitOne(); });
            }
            catch (Exception e)
            {
                Log.Debug(TAG, "StartActivityForResult() exception: " + e);
            }
            return _lastData;
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == _requestWanted)
            {
                _lastData = data;
                _event1.Set();
            }
        }
        void TextToSpeech.IOnInitListener.OnInit(OperationResult status)
        {
            _lastStatus = status;
            Log.Debug(TAG, "OnInit() status = " + status);
            _event1.Set();
        }
    }
