    public delegate void DoneLoadingHandler(object sender, EventArgs e);
    public class DataRepository
    {
        public event DoneLoadingHandler DoneLoading;
        //Your loading function
        private void LoadAllData()
        {
            //Load like you do now
    
            //Now fire the event that loading is done.
            if(DoneLoading != null)
                DoneLoading(this, new EventArgs());
        }
    }
