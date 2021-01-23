            private void btnCreate_Click(object sender, EventArgs e)
        {
            using (testEntities Setupctx = new testEntities())
            {
                station creStation = new station(){Station1=txtStation.Text,Name=NameTextbox.text,Seats = cbSeats.SelectedItem.ToString()};
                if (!Setupctx.Stations.Any(st => st.Name == creStation.Name))
                {
                    Setupctx.stations.AddObject(creStation);
                    Setupctx.SaveChanges();
                    txtStation.Text = "";
                    cbSeats.SelectedIndex = -1;
                    MessageBox.Show("New Station Has Been Created.");
                }
            }
        }
