    public class CustomerAdminService
    {
        // time in milliseconds it will take to decrease number of waiting customers 
        const int sleepTime = 10000;
        // current number of customers (just for simplicity - you can have it in db or somewhere else)
        static int numberOfCustomers;
        static Thread updaterThread;
       
        // object lock
        static readonly object locker = new Object();
        public int GetNumberOfCustomers()
        {
            return numberOfCustomers;
        }
        public void UpdateCustomers(int value)
        {
            lock (locker)
            {
                if (updaterThread == null)
                {
                    //start new downcounting thread
                    updaterThread = new Thread(new ThreadStart(UpdateWorker));
                    updaterThread.Start();
                }
                SetNumberOfWaitingCustomers(value);
            }
        }
        private void SetNumberOfWaitingCustomers(int value)
        {
            numberOfCustomers = value;
        }
        // downcounting thread method
        private void UpdateWorker()
        {      
            while (true)
            {
                // sleep for predefined time
                Thread.Sleep(sleepTime);
                lock (locker)
                {              
                    var number = GetNumberOfCustomers();             
                    if (number <= 1)
                    {
                        // if number of currents customers is now zero - end the downcounting thread
                        SetNumberOfWaitingCustomers(0);
                        updaterThread = null;
                        return;
                    }
                    SetNumberOfWaitingCustomers(number - 1);
                }
            }
        }
    }
