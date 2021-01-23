        public void print(object o)
        {
            var s = o as string;
            if(s != null)
                base.print(s);
            else
            {
                // Other code.
            }
        }
