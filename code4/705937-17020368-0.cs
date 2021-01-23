        public struct Message
        {
            string text;
            public Message(string newText)
            {
                this.text = newText;
            }
            public string Text
            {
                get
                {
                    return this.text;
                }
            }
        }
        public class Headquarters : IObservable<Message>
        {
            public Headquarters()
            {
                observers = new List<IObserver<Message>>();
            }
            private List<IObserver<Message>> observers;
            public IDisposable Subscribe(IObserver<Message> observer)
            {
                if (!observers.Contains(observer))
                    observers.Add(observer);
                return new Unsubscriber(observers, observer);
            }
            private class Unsubscriber : IDisposable
            {
                private List<IObserver<Message>> _observers;
                private IObserver<Message> _observer;
                public Unsubscriber(List<IObserver<Message>> observers, IObserver<Message> observer)
                {
                    this._observers = observers;
                    this._observer = observer;
                }
                public void Dispose()
                {
                    if (_observer != null && _observers.Contains(_observer))
                        _observers.Remove(_observer);
                }
            }
            public void SendMessage(Nullable<Message> loc)
            {
                foreach (var observer in observers)
                {
                    if (!loc.HasValue)
                        observer.OnError(new MessageUnknownException());
                    else
                        observer.OnNext(loc.Value);
                }
            }
            public void EndTransmission()
            {
                foreach (var observer in observers.ToArray())
                    if (observers.Contains(observer))
                        observer.OnCompleted();
                observers.Clear();
            }
        }
        public class MessageUnknownException : Exception
        {
            internal MessageUnknownException()
            {
            }
        }
        public class Inspector : IObserver<Message>
        {
            private IDisposable unsubscriber;
            private string instName;
            public Inspector(string name)
            {
                this.instName = name;
            }
            public string Name
            {
                get
                {
                    return this.instName;
                }
            }
            public virtual void Subscribe(IObservable<Message> provider)
            {
                if (provider != null)
                    unsubscriber = provider.Subscribe(this);
            }
            public virtual void OnCompleted()
            {
                Console.WriteLine("The headquarters has completed transmitting data to {0}.", this.Name);
                this.Unsubscribe();
            }
            public virtual void OnError(Exception e)
            {
                Console.WriteLine("{0}: Cannot get message from headquarters.", this.Name);
            }
            public virtual void OnNext(Message value)
            {
                Console.WriteLine("{1}: Message I got from headquarters: {0}", value.Text, this.Name);
            }
            public virtual void Unsubscribe()
            {
                unsubscriber.Dispose();
            }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                Inspector inspector1 = new Inspector("Greg Lestrade");
                Inspector inspector2 = new Inspector("Sherlock Holmes");
                Headquarters headquarters = new Headquarters();
                inspector1.Subscribe(headquarters);
                inspector2.Subscribe(headquarters);
                headquarters.SendMessage(new Message("Catch Moriarty!"));
                headquarters.EndTransmission();
                Console.ReadKey();
            }
        }
