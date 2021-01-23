    var selectedCity = cbCity.SelectedItem;
    var query = conn.Table<auto_fares>().Where(x => x.city == selectedCity);
    var result = await query.ToListAsync();
    foreach (var item in result)
    {
        txtDistance.Text = item.min_km.ToString();
        lblDayFare.Text = item.min_fare.ToString();
        lblNightFare.Text = item.night_charges.ToString();
    }
