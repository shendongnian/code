    public partial class ComboBoxTimeSpan : ComboBox
    {
        private BindingList<TimeSpanItemClass> _BindingList = new BindingList<TimeSpanItemClass>();
        public ComboBoxTimeSpan()
        {
            InitializeComponent();
            Items = new BindingList<TimeSpan>();
            this.Items.ListChanged += Items_ListChanged;
            this.DataSource = _BindingList;
        }
        void Items_ListChanged(object sender, ListChangedEventArgs e)
        {
            _BindingList.Clear();
            foreach (TimeSpan ts in Items)
            {
                _BindingList.Add(new TimeSpanItemClass(ts));
            }
        }
        /// <summary>
        /// The items in this combobox need to be of the type TimeSpan as this combobox is designed for showing time span values in easy to read text.
        /// </summary>
        new public BindingList<TimeSpan> Items
        {
            get;
            private set;
        }
        /// <summary>
        /// The ComboBoxTimeSpan has items that can all be converted to a time span.
        /// They will display as 1 hour, 2 hours, 1 minute, 1 hour and 2 minutes, 1 day, 2 weeks and 3 days, 3 days, etc...
        /// Its precise on the microsecond, no less
        /// </summary>
        private class TimeSpanItemClass : Object
        {
            /// <summary>
            /// The timespan that this object represents
            /// </summary>
            public TimeSpan timespan
            {
                get;
                set;
            }
            /// <summary>
            /// The constructor of this class needs a TimeSpan object
            /// </summary>
            public TimeSpanItemClass(TimeSpan ts)
            {
                timespan = ts;
            }
            /// <summary>
            /// The textual represention of the time span that this object represents.
            /// </summary>
            /// <returns>A string by a simple format</returns>
            public override string ToString()
            {
                //Specify your custom format here
                return timespan.ToString();
            }
        }
    }  
