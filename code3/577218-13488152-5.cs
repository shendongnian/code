    public static class MergeMixins
    {
        public static IObservable<int> MergeSort(this IObservable<int> This, IObservable<int> other)
        {
            return Observable.Create<int>((observer) =>
                {
                    Queue<int> BufferA = new Queue<int>();
                    Queue<int> BufferB = new Queue<int>();
                    Action<Queue<int>, int> update = (Queue<int> pushBuffer, int value)=>{
                        pushBuffer.Enqueue(value);
                        if (BufferA.Count() == 0 || BufferB.Count() == 0)
                            return;
                        if (BufferA.Peek() < BufferB.Peek())
                            observer.OnNext(BufferA.Dequeue());
                        else
                            observer.OnNext(BufferB.Dequeue());
                    };
                    return new CompositeDisposable(
                        This.Subscribe(v => update(BufferA, v)),
                        other.Subscribe(v => update(BufferB, v)));
                });
            
        }
        
    }
