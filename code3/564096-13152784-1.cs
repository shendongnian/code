    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Disposables;
    using System.Reactive.Subjects;
    public class BoolObservableConcentrator : IObservable<bool>
    {
        private readonly Dictionary<IObservable<bool>, bool> dict = new Dictionary<IObservable<bool>, bool>();
        public IDisposable Register(IObservable<bool> observable)
        {
            dict.Add(observable, false);
            var d = observable.Subscribe(value =>
            {
                dict[observable] = value;
                Fire();
            });
            return Disposable.Create(() =>
            {
                d.Dispose();
                dict.Remove(observable);
                Fire();
            });
        }
        private readonly Subject<bool> subject = new Subject<bool>();
        private void Fire()
        {
            subject.OnNext(dict.Values.All(x => x));
        }
        public IDisposable Subscribe(IObserver<bool> observer)
        {
            return subject.Subscribe(observer);
        }
    }
    
