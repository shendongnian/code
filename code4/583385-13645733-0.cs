    Dictionary<int, bool> AntennaIsEnabled = new Dictionary<int, bool>();
    foreach( KeyValuePair<int,SOME_CLASS> reader in _readerDict )
    {
      var selectedReader = reader;
      
      //From your example
      AntennaIsEnabled.Add(1, selectedReader.Value.Antenna1IsEnabled);
      AntennaIsEnabled.Add(2, selectedReader.Value.Antenna2IsEnabled);
      AntennaIsEnabled.Add(3, selectedReader.Value.Antenna3IsEnabled);
      AntennaIsEnabled.Add(4, selectedReader.Value.Antenna4IsEnabled);
    }
