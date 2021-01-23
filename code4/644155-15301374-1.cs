        public event EventHandler Custom;
        protected virtual void OnCustom(EventArgs e) {
            var handler = Custom;
            if (handler != null) {
                var subscribers = handler.GetInvocationList();
                for (int ix = subscribers.Length - 1; ix >= 0; --ix) {
                    var sub = (EventHandler)subscribers[ix];
                    sub(this, e);
                }
            }
        }
