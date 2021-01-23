    class Program {
        public static void Main() {
            var r1 = new Recognizer(@"c:\proj\test.wav");
            r1.Completed += (sender, e) => Console.WriteLine(r1.Result.Text);
    
            var r2 = new Recognizer(@"c:\proj\test.wav");
            r2.Completed += (sender, e) => Console.WriteLine(r2.Result.Text);
    
            Console.ReadLine();
        }
    }
    
    class Recognizer {
        private readonly string _fileName;
        private readonly AsyncOperation _operation;
        private volatile RecognitionResult _result;
    
        public Recognizer(string fileName) {
            _fileName = fileName;
            _operation = AsyncOperationManager.CreateOperation(null);            
            _result = null;
    
            var worker = new Action(Run);
            worker.BeginInvoke(delegate(IAsyncResult result) {
                worker.EndInvoke(result);
            }, null);            
        }
        
        private void Run() {
            try {
                SpeechRecognitionEngine engine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
                engine.SetInputToWaveFile(_fileName);
                engine.LoadGrammar(new DictationGrammar());
                engine.BabbleTimeout = TimeSpan.FromSeconds(10.0);
                engine.EndSilenceTimeout = TimeSpan.FromSeconds(10.0);
                engine.EndSilenceTimeoutAmbiguous = TimeSpan.FromSeconds(10.0);
                engine.InitialSilenceTimeout = TimeSpan.FromSeconds(10.0);
                _result = engine.Recognize();
            }
            finally {
                _operation.PostOperationCompleted(delegate {
                    RaiseCompleted();
                }, null);
            }
        }
    
        public RecognitionResult Result {
            get { return _result; }
        }
    
        public event EventHandler Completed;
    
        protected virtual void OnCompleted(EventArgs e) {
            if (Completed != null)
                Completed(this, e);
        }
    
        private void RaiseCompleted() {
            OnCompleted(EventArgs.Empty);
        }
    }
