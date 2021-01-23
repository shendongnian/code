    /// <summary> Returns the elements of the first sequence, or the values in the second sequence if the first sequence is empty. </summary>
    /// <param name="first"> The first sequence. </param>
    /// <param name="second"> The second sequence. </param>
    /// <typeparam name="T"> The type of elements in the sequence. </typeparam>
    /// <returns> The <see cref="IObservable{T}"/> sequence. </returns>
    public static IObservable<T> DefaultIfEmpty<T>(this IObservable<T> first, IObservable<T> second)
    {
        var signal = new AsyncSubject<Unit>();
        var source1 = first.Do(item => { signal.OnNext(Unit.Default); signal.OnCompleted(); });
        var source2 = second.TakeUntil(signal);
        
        return source1.Concat(source2); // if source2 is cold, it won't invoke it until source1 is completed
    }
