            private HashSet<string> events = new HashSet<string>();
            private void IsLoaded(object sender, RoutedEventArgs e)
            {
                // check
                System.Diagnostics.Debug.WriteLine(CheckEvents("IsLoaded", true).ToString());
                // add
                System.Diagnostics.Debug.WriteLine(CheckEvents("IsLoaded", false).ToString());
                // check
                System.Diagnostics.Debug.WriteLine(CheckEvents("IsLoaded", true).ToString());
            }
    
            private bool CheckEvents(string Event, bool CheckAdd)
            {
                // CheckAdd True to check
                // CheckAdd Fasle to add
                bool result = events.Contains(Event);
                if (!result && !CheckAdd) events.Add(Event);
                return result;
            }
