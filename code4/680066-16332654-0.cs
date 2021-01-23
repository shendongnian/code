    public static DeviceExtensions
    {
        public static IObservable<float[]> AsObservable(this Device device)
        {
            return Observable.CreateWithDisposable<float[]>(obs =>
            {
                IDisposable disposable = Observable.FromEvent<float[]>(
                    e => device.IncomingData += e,
                    e => device.IncomingData -= e
                    )
                    .Finally(device.Stop)
                    .Subscribe(obs);
                device.Start();
                return disposable;
            });
        }
    }
