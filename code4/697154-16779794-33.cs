    // Base class for an activity to create an initialized TextToSpeech object anynchroneously,
    // and starting intents for result anynchroneously, awaiting their result. Could be used for
    // other purposes too, remove TTS stuff if you only need StartActivityForResultAsync() 
    public class TtsAsyncActivity : Activity, TextToSpeech.IOnInitListener
    {
        protected const String TAG = "TtsSetup";
        private int _requestWanted = 0;
        private TaskCompletionSource<OperationResult> _tcsOr;
        private TaskCompletionSource<Intent> _tcsIn;
        // Creates TTS object and waits until it's initialized. Returns initialized object,
        // or null if error.
        protected async Task<TextToSpeech> CreateTtsAsync(Context context, String engName)
        {
            _tcsOr = new TaskCompletionSource<OperationResult>();
            var tts = new TextToSpeech(context, this, engName);
            if (await _tcsOr.Task != OperationResult.Success)
            {
                Log.Debug(TAG, "Engine: " + engName + " failed to initialize.");
                tts = null;
            }
            _tcsOr = null;
            return tts;
        }
        // Starts activity for results and waits for this result. Calling function may
        // inspect _lastData private member to get this result, or null if any error.
        // For sure, it could be written better to avoid class-wide _lastData member...
        protected async Task<Intent> StartActivityForResultAsync(Intent intent, int requestCode)
        {
            Intent data = null;
            try
            {
                _tcsIn = new TaskCompletionSource<Intent>();
                _requestWanted = requestCode;
                StartActivityForResult(intent, requestCode);
                // possible exceptions: ActivityNotFoundException, also got SecurityException from com.turboled
                data = await _tcsIn.Task;
            }
            catch (Exception e)
            {
                Log.Debug(TAG, "StartActivityForResult() exception: " + e);
            }
            _tcsIn = null;
            return data;
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == _requestWanted)
            {
                _tcsIn.SetResult(data);
            }
        }
        void TextToSpeech.IOnInitListener.OnInit(OperationResult status)
        {
            Log.Debug(TAG, "OnInit() status = " + status);
            _tcsOr.SetResult(status);
        }
    }
