    public static class MergeMixins
    {
        public static IObservable<int> MergeSort(
                this IObservable<int> This, 
                IObservable<int> other)
        {
            return Observable.Create<int>((observer) =>
                {
                    Queue<int> BufferA = new Queue<int>();
                    Queue<int> BufferB = new Queue<int>();
                    var d0 = This.Subscribe(v =>
                    {
                        BufferA.Enqueue(v);
                        if (BufferB.Count() != 0)
                        {
                            if (BufferA.Peek() < BufferB.Peek())
                                observer.OnNext(BufferA.Dequeue());
                            else
                                observer.OnNext(BufferB.Dequeue());
                        }
                    });
                    var d1 = other.Subscribe(v =>
                    {
                        BufferB.Enqueue(v);
                        if (BufferA.Count() != 0)
                        {
                            if (BufferA.Peek() < BufferB.Peek())
                                observer.OnNext(BufferA.Dequeue());
                            else
                                observer.OnNext(BufferB.Dequeue());
                        }
                    });
                    return new CompositeDisposable(d0, d1);
                });
            
        }
        
    }
