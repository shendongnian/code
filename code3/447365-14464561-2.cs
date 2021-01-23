        /// <summary>
        /// Initialize a new instance of the <see cref="MainView"/> class.
        /// </summary>
        public MainView()
        {
            InitializeComponent();
            Messenger.Default.Register<SaveFileDialogMessage>(this, msg =>
                                                                    {
                                                                        var sfd = new SaveFileDialog { Filter = msg.Filter, Title = msg.Title };
                                                                        var result = sfd.ShowDialog();
                                                                        msg.ProcessCallback(result, sfd.FileName);
                                                                    });
        }
