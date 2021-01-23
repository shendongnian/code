    public partial class MyLookupBoxes : UserControl
    {
        public LookupBox()
        {
            // Add the 3 LookupBox to this UserControl using the designer
            InitializeComponent();
            SetupDataSources();
        }
        private void SetupDataSources()
        {
            namesLookupBox1.DataSource = names_data_source_1;
            // ...
            typesLookupBox2.DataSource = types_data_srouce_2;
            // ...
            productsLookupBox3.DataSource = products_data_srouce_2;
            // ...
        }
    }
