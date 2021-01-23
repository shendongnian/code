    Payroll.Entities.City city1;
    using (CityService cs = new CityService())
    {
      city1 = cs.SelectCity(Convert.ToInt64(cmbCity.SelectedItem.Value));
    }
