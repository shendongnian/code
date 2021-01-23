        public bool chcked 
        {
            get { return c; }
            set 
            {
                if (c && value)
                {
                    c = false;
                    return;
                }
                c = value; 
            } 
        }
