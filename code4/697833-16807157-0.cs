        private void myMap_Tap(object sender, GestureEventArgs e)
        {
            // removal queue for existing pins
            var toRemove = new List<UIElement>();
            // iterate through all children that are PushPins. Could also use a Linq selector
            foreach (var child in myMap.Children)
            {
                if (child is Pushpin)
                {
                    // queue this child for removal
                    toRemove.Add(child);
                }
            }
            // now do the actual removal
            foreach (var child in toRemove)
            {
                myMap.Children.Remove(child);
            }
            // now add in 10 new PushPins
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                var pin = new Pushpin();
                pin.Location = new System.Device.Location.GeoCoordinate() { Latitude = rand.Next(90), Longitude = rand.Next(-180, 180) };
                myMap.Children.Add(pin);
            }
        }
