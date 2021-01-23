    using Microsoft.Reactive.Testing;
    using System;
    using System.Diagnostics;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    
    namespace ButtonTest
    {
        class Program
        {
            enum State
            {
                KeyDown, KeyUp
            }
    
            static void Main(string[] args)
            {
                var buttonState = new BehaviorSubject<State>(State.KeyUp);
                var testScheduler = new TestScheduler();
                var events = testScheduler.CreateObserver<long>();
    
                Observable.Interval(TimeSpan.FromTicks(100), testScheduler)
                    .CombineLatest(buttonState, (t,s)=> new { TimeStamp = t, ButtonState = s })
                    .Where(t => t.ButtonState == State.KeyDown)
                    .Select(t => t.TimeStamp)
                    .Subscribe(events);
    
                testScheduler.AdvanceBy(100);//t=0
                testScheduler.AdvanceBy(100);//t=1
    
                buttonState.OnNext(State.KeyDown);
                testScheduler.AdvanceBy(100);//t=2
    
                testScheduler.AdvanceBy(100);//t=3
                buttonState.OnNext(State.KeyUp);
    
                testScheduler.AdvanceBy(100);//t=4
                testScheduler.AdvanceBy(100);//t=5
    
                buttonState.OnNext(State.KeyDown);
                testScheduler.AdvanceBy(100);//t=6
    
                buttonState.OnNext(State.KeyUp);
    
                testScheduler.AdvanceBy(100);//t=7
                testScheduler.AdvanceBy(100);//t=8
    
                Debug.Assert(events.Messages.Count == 5);
                Debug.Assert(events.Messages[0].Value.Value == 1);
                Debug.Assert(events.Messages[1].Value.Value == 2);
                Debug.Assert(events.Messages[2].Value.Value == 3);
                Debug.Assert(events.Messages[3].Value.Value == 5);
                Debug.Assert(events.Messages[4].Value.Value == 6);
            }
        }
    }
