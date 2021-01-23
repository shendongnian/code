    public class YourDataModel
    {
        public property int CallHour { get;set; }
        public property int CallCounter { get;set; }
        public YourDataModel(callHour int, callCounter int)
        {
           CallHour = callHour;
           CallCounter = callCounter;
        }
    }
    public partial class MainWindow : Window
    {
        private ObservableCollection<YourDataModel> dataModel; 
        
        public MainWindow()
        {
            InitializeComponent();
            dataModel = new ObservableCollection<YourDataModel>();
            //set itemsource property or you can bind from XAML
            //which is name columnseries x:Name=CallsPerHour
            CallsPerHour.ItemsSource = dataModel;
        }
        //when date change running this function
        private void GettingDataFromSql()
        {
            ...
            while (reader.Read())
            {
                YourDataModel data = new YourDataModel( reader.GetInt32(2), 
                reader.GetInt32(3));
                dataModel.Add(data);
            }
        }
    }
