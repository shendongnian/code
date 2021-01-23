     <Grid>
        <TabControl SelectionChanged="TabControl_SelectionChanged_1">
            <TabItem x:Name="tabitem1" Header="abc" />
            <TabItem x:Name="tabitem2"  Header="xyz"/>
        </TabControl>
    </Grid>
     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool tab1ItemLoaded = false;
        private bool tab2ItemLoaded = false;
        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (tabitem1.IsSelected && !tab1ItemLoaded)
            {
                //load tab1 data
                tab1ItemLoaded = true;
            }
            else if (tabitem2.IsSelected && !tab2ItemLoaded)
            {
                //load tab2 data
                tab2ItemLoaded = true;
            }
        }
    }
