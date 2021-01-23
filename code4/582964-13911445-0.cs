        public class GetPhoneGPS : IDisposable
        {
            private static readonly Positions Position = new Positions();
            readonly GeoCoordinateWatcher _watch = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            private void UpdatePhonePosition()
            {
                _watch.MovementThreshold = 1;
                _watch.Start();
                _watch.PositionChanged += GeoPositionChange;
                var position = _watch.Position;
                //loads phones gps coordinates
                if (!position.Location.IsUnknown)
                {
                    Position.Latitude = position.Location.Latitude.ToString(CultureInfo.InvariantCulture);
                    Position.Longitude = position.Location.Longitude.ToString(CultureInfo.InvariantCulture);
                    Position.Altitude = position.Location.Altitude.ToString(CultureInfo.InvariantCulture);
                    Position.Speed = position.Location.Speed.ToString(CultureInfo.InvariantCulture);
                }
                Position.Date = DateTime.Now;
                Position.Name = PhoneApplicationService.Current.State["username"].ToString();
                Position.UniqueId = PhoneApplicationService.Current.State["UniqueId"].ToString();
            }
            private void GeoPositionChange(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
            {
                var position = e.Position;
                //loads phones gps coordinates
                if (!position.Location.IsUnknown)
                {
                    Position.Latitude = position.Location.Latitude.ToString(CultureInfo.InvariantCulture);
                    Position.Longitude = position.Location.Longitude.ToString(CultureInfo.InvariantCulture);
                    Position.Altitude = position.Location.Altitude.ToString(CultureInfo.InvariantCulture);
                    Position.Speed = position.Location.Speed.ToString(CultureInfo.InvariantCulture);
                }
                Position.Date = DateTime.Now;
            }
            public Positions Positions()
            {
                UpdatePhonePosition();
                return Position;
            }
            public void Dispose()
            {
                _watch.Dispose();
            }
        }
