        protected void VehiclesGridView_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
        {
            if (ChangeAttemptedId && !IsSavedId)
            {
                Alert.Show("Dispatch assignment saved... (But you forgot to click Confirm or Cancel!)");
            }
            IsSavedId = false;
            ChangeAttemptedId = true;
            int selectedIndex = e.NewSelectedIndex;
            getNextRide(selectedIndex); //TODO: FIX             
        }
