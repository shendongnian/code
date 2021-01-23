    public class DataContainer
    {
        public string Description {get;set;}
        public GeoCoordinate Coordinate {get;set;} 
    }
    var descriptions = new[] {"Pierwszy" , "Drugi" , "Trzeci" }; //etc
    var zipped = mySimulationCoordinates.Zip(descriptions, (coord, desc) => new DataContainer { Description = desc, Coordinate = coord });
    foreach(var item in zipped)
    {
        var currentItem = item;
        using(var waitHandle = new AutoResetEvent(false))
        {
            var geocodeQuery = new ReverseGeocodeQuery();
            geocodeQuery.GeoCoordinate = currentItem.Coordinates;
            geocodeQuery.QueryCompleted += (sender, args) => {
                if (e.Error == null)
                {
                    if (e.Result.Count > 0)
                    {
                        MapAddress address = e.Result[0].Information.Address;
                        label8txt.Text = address.City.ToString() + "\n" + address.Street.ToString();
                        StringBuilder str = new StringBuilder();
                        str.AppendLine(currentItem.Description);
                        str.AppendLine("11" + address.HouseNumber);
                        str.AppendLine("17" + address.Street);
                        MessageBox.Show(str.ToString());
                        waitHandle.Set();
                    }
                }
            };
            geoCodeQuery.QueryAsync();
            waitHandle.WaitOne();
        }
    }
