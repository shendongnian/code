        public async void MyMethod()
        {
            while(true)
            {
                send("OK");
                await WaitMethod();
            }
        }
