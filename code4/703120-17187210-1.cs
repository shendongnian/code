        private bool _isInView = false;
        public bool IsInView
        {
            get { return _isInView; }
            set
            {
                if (_isInView != value)
                {
                    if (value)
                        InView();
                    else
                        OutView();
                }
                _isInView = value;
            }
        }
        private void InView()
        {
            Game.ObjectDrawEventHandler.Add(Draw);
        }
        private override void OutView()
        {
            Game.ObjectDrawEventHandler.Remove(Draw);
        }
