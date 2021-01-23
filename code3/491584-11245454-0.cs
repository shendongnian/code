        LinkedList<DateTime> myAccessList = new LinkedList<DateTime>();
        private void Access_Detected()
        {
            myAccessList.AddLast(DateTime.Now);
        }
        public int MyPriority
        {
            get
            {
                DateTime expiry = DateTime.Now.Subtract(TIME_TO_LIVE);
                while (myAccessList.First.Value < expiry)
                {
                    myAccessList.RemoveFirst();
                }
                return myAccessList.Count;
            }
        }
