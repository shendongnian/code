        private ObjectA _SelectedObjectA;
        public ObjectA SelectedObjectA
        {
            get
            {
                return _SelectedObjectA;
            }
            set
            {
                if (_SelectedObjectA == value)
                    return;
                _SelectedObjectA = value;
                // Notifu changed here
            }
        }
