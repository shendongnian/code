        public IDisposable Subscribe(IObserver<T> observer)
        {
            lock (_subscriberSync)
            {
                var accepted = OnSubscribing(observer);   // <------ policy can be applied here
                if (!accepted)
                {
                    observer.OnError(new SubscriptionRejectedException("reason"));
                    return Disposable.Empty;
                }
                // ... perform actual subscription went here
            }
        }
