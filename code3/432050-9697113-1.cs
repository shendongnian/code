        public void RejectChanges()
        {
            Func<object, PropertyChangedEventArgs> handler = (sender, e) =>
                {
                    RaisePropertyChanged(e.PropertyName);
                };
            _foo.PropertyChanged += handler;
            _context.RejectChanges();
            _foo.PropertyChanged -= handler;
        }
