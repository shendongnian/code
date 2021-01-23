        ObservableCollection<string> myList;
        public MainPage()
        {
            InitializeComponent();
            myList = new ObservableCollection<string>();
            myList.Add("A");
            myList.Add("B");
            myList.Add("C");
            myList.Add("D");
            myList.Add("E");
            System.Threading.Timer t = new System.Threading.Timer(new System.Threading.TimerCallback(TimerFired));
            t.Change(500, 500);
            listBox2.ItemsSource = myList ;          
        }
        private void TimerFired(object sender)
        {
            Pop();
        }
        private delegate void PopDelegate();
        private void Pop()
        {
            if (this.Dispatcher.CheckAccess())
            {
                string item = myList[myList.Count - 1];
                myList.RemoveAt(myList.Count - 1);
                myList.Insert(0, item);
               
            }
            else
            {
                this.Dispatcher.BeginInvoke(new PopDelegate(Pop), null);
            }
        }
