    public partial class AnotherClass
    {
        public delegate void ReallyLongProcessProgressHandler(double percentComplete);
        public event ReallyLongProcessProgressHandler ProgressUpdate;
        private void UpdateProgress(double percent)
        {
            if (this.ProgressUpdate != null)
            {
                this.ProgressUpdate(percent);
            }
        }
        public void AVeryLongTimedFunction()
        {
            //Do something AWESOME
            List<Item> items = GetItemsToProcessFromSomewhere();
            for (int i = 0; i < items.Count; i++)
            {
                if (i % 50)
                {
                   this.UpdateProgress(((double)i) / ((double)items.Count)
                }
                //Process item
            }
        }
    }
