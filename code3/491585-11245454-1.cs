        static TimeSpan TIME_TO_LIVE;
        static int userOrderFactor = 0;
        LinkedList<KeyValuePair<DateTime, int>> myAccessList = new     LinkedList<KeyValuePair<DateTime, int>>();
        
        private void Access_Detected()
        {
            userOrderFactor++;
            myAccessList.AddLast(new KeyValuePair<DateTime, int>(DateTime.Now, userOrderFactor));
            myPriority += userOrderFactor; // take total count differential, so we dont waste time summing the list
        }
        
        private int myPriority = 0;
        public int MyPriority
        {
            get
            {
                DateTime expiry = DateTime.Now.Subtract(TIME_TO_LIVE);
                while (myAccessList.First.Value.Key < expiry)
                {
                    myPriority += myAccessList.First.Value.Value; // take care of the Total Count 
                    myAccessList.RemoveFirst();
                }
                return myPriority;
            }
        }
