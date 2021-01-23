        public event EventHandler<EventArgs> _event;
        public event EventHandler<EventArgs> PublicEvent
        {
            add
            {
                if (_event == null)
                    _event += value;
            }
            remove
            {
                _event -= value;
            }
        }
