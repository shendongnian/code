    public MainWindow()
        {
            InitializeComponent();
        }
        public void WindowLoaded(object sender, EventArgs e) 
        {
            listbox = new ListBox { Margin = new Thickness(10.0), MinWidth = 400, MinHeight = 400 };
            listbox.Items.Add(new string('c', 3000));
            var sv = new ScrollViewer { HorizontalScrollBarVisibility = ScrollBarVisibility.Auto, VerticalScrollBarVisibility = ScrollBarVisibility.Auto };
            sv.Content = listbox; // remove for test
            this.Width = 600;
            this.Height = 400;
            this.Content = sv;
        }
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            if (listbox != null)
                listbox.MaxWidth = this.RenderSize.Width - (int.Parse(listbox.Margin.Right.ToString()) * 4);
        }
