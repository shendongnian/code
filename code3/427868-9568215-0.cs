        void OnInfoChanged(object o)
        {
            // Update label
        }
        protected void SomeWorkerThread(object o)
        {
            int i = 0;
            while(true)
            {
                if( i % 10 == 0 )
                {
                    if(InfoChangeEvent != null)
                    {
                        InfoChangeEvent(i);
                    }
                }
                Thread.Sleep(1000);
                i++;
            }
        }
