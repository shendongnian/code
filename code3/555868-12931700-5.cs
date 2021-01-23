        public void DoSomethingMethod(Action<int> progressCallback)
        {
            while(true)
            {
                // do something here
                // return the progress
                int progress = stuff_done / stuff_total * 100;
                progressCallback(progress);
            }
        }
