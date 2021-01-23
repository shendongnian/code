        private static IObservable<int> ErrorProducer(int i)
        {
            int count = 0;
            return Observable.Create<int>(observer =>
            {
                Console.WriteLine("Doing work");
                if (count++ < i)
                {
                    Console.WriteLine("Failed");
                    observer.OnError(new Exception());
                }
                else
                {
                    Console.WriteLine("Done");
                    observer.OnNext(count);
                    observer.OnCompleted();                    
                }
                return Disposable.Empty;
            });
        }
