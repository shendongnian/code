    private void lstFlights_SelectedIndexChanged(object sender, EventArgs e)
    {
            curFlight = flightList.FirstOrDefault(x => x.Plane == lstFlights.SelectedItem.ToString()); // Changed this line
            txtDepart.Text = curFlight.DepartureTime;
            txtDestination.Text = curFlight.Destination;
    }
