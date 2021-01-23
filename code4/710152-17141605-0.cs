        AutoResetEvent done;
        int remaining;
        private async void SimulationResults()
        {
            done = new AutoResetEvent(true);
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracy = PositionAccuracy.High;
            var myCoordinate = new GeoCoordinate(51.751985, 19.426515);
            var mySimulation = new List<GeoCoordinate>()
            {
                new GeoCoordinate(51.751985, 19.426515),
                new GeoCoordinate(2, 2)
            };
            //mySimulation = Simulation.SimulationProcess(myCoordinate, 120); // Odległość
            remaining = mySimulation.Count;
            for (int i = 0; i < mySimulation.Count; i++)
            {
                done.WaitOne();
                //if (mySimulation.ElementAt(i).Id == 1 | mySimulation.ElementAt(i).Id == -1)
                //{
                    // Oczekiwanie, ponieważ obiekt jest zasygnalizowany od razu wejdziemy
                    // do sekcji krytycznej
                    //AddMapLayer(mySimulation.ElementAt(i).Coordinate, Colors.Yellow, false);
                var tempI = i;
                Dispatcher.BeginInvoke(() =>
                {
                    
                    var myReverseGeocodeQuery_1 = new ReverseGeocodeQuery();
                    myReverseGeocodeQuery_1.GeoCoordinate = mySimulation.ElementAt(tempI);
                    myReverseGeocodeQuery_1.QueryCompleted += ReverseGeocodeQuery_QueryCompleted_1;
                    // Sekcja krytyczna
                    done.Reset(); // Hey I'm working, wait!
                    myReverseGeocodeQuery_1.QueryAsync();
                });
                //}
            }
        }
        private void ReverseGeocodeQuery_QueryCompleted_1(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
        {
            done.Set();
            
            remaining--;
            if (e.Error == null)
            {
                if (e.Result.Count > 0)
                {
                    MapAddress address = e.Result[0].Information.Address;
                    Dispatcher.BeginInvoke(() =>
                    {
                        MessageBox.Show("Wykonano " + address.Street);
                    });
                }
            }
            if (remaining == 0)
            {
                // Do all done code
                Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show("Skonczylem");
                });
            }
        } 
