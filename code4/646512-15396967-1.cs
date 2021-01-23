    public static class ObservableHelper
    {
        /// <summary>
        /// Buffers entries that do no satisfy the <paramref name="shouldFlush"/> condition, using a circular buffer with a max
        /// capacity. When an entry that satisfies the condition ocurrs, then it flushes the circular buffer and the new entry,
        /// and starts buffering again.
        /// </summary>
        /// <typeparam name="T">The type of entry.</typeparam>
        /// <param name="stream">The original stream of events.</param>
        /// <param name="shouldFlush">The condition that defines whether the item and the buffered entries are flushed.</param>
        /// <param name="bufferSize">The buffer size for accumulated entries.</param>
        /// <returns>An observable that has this filtering capability.</returns>
        public static IObservable<T> FlushOnTrigger<T>(this IObservable<T> stream, Func<T, bool> shouldFlush, int bufferSize)
        {
            if (stream == null) throw new ArgumentNullException("stream");
            if (shouldFlush == null) throw new ArgumentNullException("shouldFlush");
            if (bufferSize < 1) throw new ArgumentOutOfRangeException("bufferSize");
            return System.Reactive.Linq.Observable.Create<T>(observer =>
            {
                var buffer = new CircularBuffer<T>(bufferSize);
                var subscription = stream.Subscribe(
                    newItem =>
                        {
                            bool result;
                            try
                            {
                                result = shouldFlush(newItem);
                            }
                            catch (Exception ex)
                            {
                                return;
                            }
                            if (result)
                            {
                                foreach (var buffered in buffer.TakeAll())
                                {
                                    observer.OnNext(buffered);
                                }
                                observer.OnNext(newItem);
                            }
                            else
                            {
                                buffer.Add(newItem);
                            }
                        },
                    observer.OnError,
                    observer.OnCompleted);
                return subscription;
            });
        }
    }
