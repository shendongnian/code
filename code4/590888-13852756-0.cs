    public class Subscriber<T> {
        private int _UserID;
        private T _Subscription;
        public int UserID {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public T Subscription {
            get { return _Subscription; }
            set { _Subscription = value; }
        }
    }
