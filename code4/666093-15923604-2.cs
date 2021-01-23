    public MainWindowViewModel
    {
        public ObservableCollection<ViewModelBase> Flights { get; set; }
        public MainWindowViewModel()
        {
            Flights = new ObservableCollection<ViewModelBase>();
            Flights.Add(new InFlightViewModel());
            Flights.Add(new OutFlightViewModel());
        }
    }
    public class FlightTemplateSelector : DataTemplateSelector
    {
        public DataTemplate InFlightTemplate { get; set; }
        public DataTemplate OutFlightTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, 
                                                    DependencyObject container)
        {
            if(item.GetType() == typeof(InFlight))
                return InFlightTemplate;
            if(item.GetType() == typeof(OutFlight))
                return OutFlightTemplate
            
            //Throw exception or choose some random layout
            throw new Exception();
        }
     }
    <local:FlightTemplateSelector
        x:Key="FlightTemplateSelector">
        <local:FlightTemplateSelector.InFlightTemplate>
           <!-- Define your layout here -->
        </local:FlightTemplateSelector.InFlightTemplate>
           <!-- Define your layout here -->
        <local:FlightTemplateSelector.OutFlightTemplate>
        </local:FlightTemplateSelector.OutFlightTemplate>
    </local:FlightTemplateSelector>
