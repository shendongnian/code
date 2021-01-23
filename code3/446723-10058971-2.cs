        private IObservable<List<string>> ImportWords()
        {
            Subject<List<string>> contx = new Subject<List<string>>();
            new Thread(new ThreadStart(() =>
                {
                    //waits for the user to finish formatting his words correctly
                    for (; ; ) 
                    { 
                        if (FormatWindowOpen != true) 
                        {
                            contx.OnNext(ExtractWords(FormattedText));
                            contx.OnCompleted();
                        }
                    }
                })).Start();
            return contx;
        }
