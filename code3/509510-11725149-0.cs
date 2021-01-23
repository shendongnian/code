    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private SomeBackgroundThing thing;
        private DataTable wpftable;
        public DataTable table
        {
            get
            {
                lock (wpftable)
                {
                    return wpftable;
                }
            }
            set
            {
                lock (wpftable)
                {
                    wpftable = value;
                }
            }
        }
        public MainWindowViewModel(SomeBackgroundThing thing)
        {
            wpftable = thing.table.Copy();
            this.thing = thing;
            thing.Changed += new EventHandler(thing_Changed);
        }
        void thing_Changed(object sender, EventArgs e)
        {
            if (PropertyChanged != null)
            {
                DataTable wpftablecopy = wpftable.Copy();
                DataTable thintablecopy = thing.table.Copy();
                int rowcount = wpftablecopy.Rows.Count;
                for (int col = 0; col < 4; col++)
                {
                    for (int row = 0; row < rowcount; row++)
                    {
                        if (wpftablecopy.Rows[row][col] != thintablecopy.Rows[row][col])
                            wpftable.Rows[row][col] = thintablecopy.Rows[row][col];
                    }
                }
                PropertyChanged(this, new PropertyChangedEventArgs("table"));
            }
        }
    }
