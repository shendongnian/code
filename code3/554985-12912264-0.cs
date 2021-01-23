    Timer tm; //Moved to a field
    
    public MainForm()
            {
                InitializeComponent();
                tm =
                    new System.Threading.Timer(state => statusDateTimeLabel.Text = DateTime.Now.ToLocalTime().ToString(CultureInfo.InvariantCulture), null, TimeSpan.FromMilliseconds(0),
                    TimeSpan.FromMilliseconds(1000));                
            }
