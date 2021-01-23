    class Entity
    {
        private Manager _manager = null;
        public Manager manager
        {
            get
            {
                return _manager;
            }
            set
            {
                if (manager == null)
                {
                    _manager = value;
                }
            }
        }
        /* rest of class */
    }
