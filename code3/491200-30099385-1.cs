                loc.DesiredAccuracy = PositionAccuracy.High;
                
                Geoposition pos = await loc.GetGeopositionAsync();
                var lat = pos.Coordinate.Point.Position.Latitude;
                var lang = pos.Coordinate.Point.Position.Longitude;
                Status = loc.LocationStatus;
                return GetGpsInfoObject(pos);
            }
            catch (Exception)
            {
                return null;
            }
