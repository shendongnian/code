        void Done()
        {
            this.Context.Post(new SendOrPostCallback(DoneSynchronized), null);
        }
        void DoneSynchronized(object state)
        {
            //place here code You now have in Done method.
        }
