            //highestWeightedEvents is a DataTable
            highestWeightedEvents = BuildHighestWeightedEventsTable();
            MainSeries.DependentValueBinding = new Binding("Cutset_Frequency");
            MainSeries.IndependentValueBinding = new Binding("Event_Number");
            MainSeries.ItemsSource = highestWeightedEvents.DefaultView;
