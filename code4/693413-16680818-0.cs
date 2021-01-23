        private void SetupEvents()
        {
            var observableA = Observable.FromEventPattern((e) => btA.Click += e, (e) => btA.Click -= e);
            var observableB = Observable.FromEventPattern((e) => btB.Click += e, (e) => btB.Click -= e);
            EventPattern<object> lastA = null;
            EventPattern<object> lastB = null;
            var observableG = observableA.CombineLatest(observableB, (rA, rB) =>
            {
                if (lastA == rA || lastB == rB)
                    return null;
                lastA = rA;
                lastB = rB;
                return new Tuple<EventPattern<object>, EventPattern<object>>(rA, rB);
            }).Where(p => p != null);
            observableG.Subscribe(r => Trace.WriteLine("A + B"));
            // or use ToEvent to generate another standard .NET event
            //observableG.ToEvent().OnNext += GEvent;
        }
        //void GEvent(System.Reactive.EventPattern<object> obj)
        //{
        //    Trace.WriteLine("A + B");
        //}
