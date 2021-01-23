    public List<SightingType> sightingT = new List<SightingType>();
    
    private void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
                DataContractJsonSerializer ser = null;
    
                try
                {
                    ser = new DataContractJsonSerializer(typeof(ObservableCollection<SightingType>));
                    ObservableCollection<SightingType> sightingTypes = ser.ReadObject(e.Result) as ObservableCollection<SightingType>;
                    foreach (var sightingType in sightingTypes)
                    {
                        sightingT.Add(sightingType);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
    
                
     }
