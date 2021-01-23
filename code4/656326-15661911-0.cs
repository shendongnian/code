    class Table
        {
            Dictionary<String, double> _regionTimeValues;
            String _region;
    
            public Table(String region)
            {
                _regionTimeValues = new Dictionary<string, double>();
                _region = region;
                suckInValues();
            }
    
            private void suckInValues()
            {
                //Go find Excel File, get the appropriate Values
                //for each value found
            }
    
    
            internal double locateRelevantValue(string yearQuarter)
            {
                double locatedValue = 0.0;
                _regionTimeValues.TryGetValue(yearQuarter,out locatedValue);
                return locatedValue;
                
            }
        }
