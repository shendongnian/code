       public static readonly DependencyProperty AdressRecordsProperty =
           DependencyProperty.Register("AdressRecords", 
               typeof(ObservableCollection<AdressRecord>), 
               typeof(PageViewModel), 
               new FrameworkPropertyMetadata(
                   default(AdressRecord),//This noes not work: new AdressRecord { Name = "<new>", Adress = "?" },
                   OnAdressRecordsChanged));
