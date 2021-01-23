	var realWD = Environment.CurrentDirectory;
	Environment.CurrentDirectory =
            System.IO.Path.GetDirectory(
                System.Reflection.Assembly.GetEntryAssembly().Location);
	InitializeComponent();
	Environment.CurrentDirectory = realWD;
