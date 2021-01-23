        /// <summary>
        /// Is this location selected in the UI?
        /// </summary>
        public bool Selected
        {
            get { return _selected; }
            set
            {
                if ( value != _selected )
                {
                    _selected = value;
                    RaisePropertyChanged( "Selected" );
                }
            }
        }
