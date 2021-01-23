            public void GenerateCSV(List<LocationData> data)
        {
            foreach (LocationData d in data)
            {
                //put line in csv as
                string s = d.PostalCode + "," d.Partner + _"," + d.LocationID...... + Environment.NewLine;
            }
        }
