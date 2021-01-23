		public MyWindow()
		{
			VM = new MyViewModelsNamespace.MyViewModel();
            this.DataContext = VM;
			InitializeComponent();
		}
        public void ExecuteMyCommand(object sender, ExecutedRoutedEventArgs e)
        {
            VM.MyList.Add(new MyItemClass{MyItemText="some text"});
        }
        public void CanExecuteMyCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (...) e.CanExecute = false;
            else e.CanExecute = true;
        }
