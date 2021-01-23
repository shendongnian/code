    private void btnCreate_Click(object sender, EventArgs e)
        {
            using (testEntities Setupctx = new testEntities())
            {
                string[] stations = StationNameList();
                station creStation = new station();
                creStation.Station1 = txtStation.Text;
                creStation.Seats = cbSeats.SelectedItem.ToString();
                if (stations.Contains(txtStation.Text))
                {
                    MessageBox.Show("This Station is already been created. Please enter a new Station.");
                }
                else
                {
                    Setupctx.stations.AddObject(creStation);
                    Setupctx.SaveChanges();
                    txtStation.Text = "";
                    cbSeats.SelectedIndex = -1;
                    MessageBox.Show("New Station Has Been Created.");
                }
            }
        }
