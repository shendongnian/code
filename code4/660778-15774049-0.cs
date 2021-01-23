    public partial class MainWindow : Window
    {
        public struct SwapIndex
        {
            public int i; public int j;
        };
        delegate void UIswap(int i, int j);
        const int scale = 4;
        const int size = 50;
        Int32[] data = new Int32[size];
        bool Working = false;
        Line[] lines = new Line[size];
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Draw();
        }
        private void Draw()
        {
            canvas1.Children.Clear();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
                lines[i] = new Line()
                {
                    X1 = 0,
                    Y1 = i * scale,
                    X2 = i * scale,
                    Y2 = i * scale,
                    StrokeThickness = 2,
                    Stroke = new SolidColorBrush(Colors.Black)
                };
                canvas1.Children.Add(lines[i]);
            }
        }
        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            if (Working) return;
            Working = true;
            Thread T1 = new Thread(new ThreadStart(BubbleSimple));
            T1.Start();
        }
        void BubbleSimple()
        {
            bool flag = false;
            do
            {
                flag = false;
                for (int i = 0; i < data.Length - 1; i++)
                {
                    if (data[i] > data[i + 1])
                    {
                        flag = true;
                        swapData(i, i + 1);
                    }
                    Thread.Sleep(10);
                }
            } while (flag);
            Working = false;
        }
        private void swapData(int i, int j)
        {
            var temp = data[i];
            data[i] = data[j];
            data[j] = temp;
            UIswap swap = (i1, j1) =>
            {
                var tempd = lines[i1].X2;
                lines[i1].X2 = lines[j1].X2;
                lines[j1].X2 = tempd;
            };
            canvas1.Dispatcher.BeginInvoke(swap, new object[] { i, j });
        }
        void Randomize(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;
            Random R = new Random();
            for (int i = 0; i < data.Length; i++)
            {
                int j = R.Next(data.Length);
                bw.ReportProgress(1, new SwapIndex() { i = i, j = j });
            }
        }
        void SwapLine(object sender, ProgressChangedEventArgs e)
        {
            int i = ((SwapIndex)e.UserState).i;
            int j = ((SwapIndex)e.UserState).j;
            int t = data[i];
            data[i] = data[j];
            data[j] = t;
            double temp;
            temp = lines[i].X2;
            lines[i].X2 = lines[j].X2;
            lines[j].X2 = temp;
        }
        private void Suffle_Click(object sender, RoutedEventArgs e)
        {
            if (Working) return;
            Working = true;
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = false;
            bw.DoWork += new DoWorkEventHandler(Randomize);
            bw.ProgressChanged += new ProgressChangedEventHandler(SwapLine);
            bw.RunWorkerCompleted += delegate(object s1, RunWorkerCompletedEventArgs e1)
            {
                Working = false;
            };
            bw.RunWorkerAsync();
        }
    }
