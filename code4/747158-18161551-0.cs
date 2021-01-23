    <Grid toolkit:TiltEffect.IsTiltEnabled="True">
        <Image Source="Background.png" />
    </Grid>
    public MainPage()
    {
        InitializeComponent();
        TiltEffect.TiltableItems.Add(typeof(Grid));    
    }
