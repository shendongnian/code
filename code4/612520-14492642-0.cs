    private void Maps_GeoCoding(object sender, RoutedEventArgs e)
    {
        GeocodeQuery query = new GeocodeQuery()
        {
            GeoCoordinate = new GeoCoordinate(0, 0),
            SearchTerm = "Ferry Building, San-Francisco"
        };
         query.QueryCompleted += query_QueryCompleted;
        query.QueryAsync();
    }
     
    void query_QueryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Ferry Building Geocoding results...");
        foreach (var item in e.Result)
        {
            sb.AppendLine(item.GeoCoordinate.ToString());
            sb.AppendLine(item.Information.Name);
            sb.AppendLine(item.Information.Description);
            sb.AppendLine(item.Information.Address.BuildingFloor);
            sb.AppendLine(item.Information.Address.BuildingName);
            sb.AppendLine(item.Information.Address.BuildingRoom);
            sb.AppendLine(item.Information.Address.BuildingZone);
            sb.AppendLine(item.Information.Address.City);
            sb.AppendLine(item.Information.Address.Continent);
            sb.AppendLine(item.Information.Address.Country);
            sb.AppendLine(item.Information.Address.CountryCode);
            sb.AppendLine(item.Information.Address.County);
            sb.AppendLine(item.Information.Address.District);
            sb.AppendLine(item.Information.Address.HouseNumber);
            sb.AppendLine(item.Information.Address.Neighborhood);
            sb.AppendLine(item.Information.Address.PostalCode);
            sb.AppendLine(item.Information.Address.Province);
            sb.AppendLine(item.Information.Address.State);
            sb.AppendLine(item.Information.Address.StateCode);
            sb.AppendLine(item.Information.Address.Street);
            sb.AppendLine(item.Information.Address.Township);
        }
        MessageBox.Show(sb.ToString());
    }
