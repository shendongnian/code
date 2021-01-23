        bool cancelJob = false;
        ThreadStart ts = new System.Threading.ThreadStart(CheckLicence);
        Thread thMain = new System.Threading.Thread(ts);
        thMain.Start();
        void CheckLicence()
        {
            //you can use cancelJob to break the thread...
            while (!this.cancelJob)
            {
                //TODO: code to check your licence...
                //sleep for 1 hour...
                System.Threading.Thread.Sleep(3600000);
            }
        }
