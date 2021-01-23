        public B(A a)
        {
            a.MyEvent += (sender, e) => OnMyOtherEvent(e);
        }
    }
