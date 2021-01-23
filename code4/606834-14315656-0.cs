        private xRoute.Point ConvertXLocate2XRoute(xLocate.Point point)
        {
            return new xRoute.Point
            {
                kml = new Kml   // Replace by the actual name of this type
                {
                    kml = point.kml.kml,
                    wrappedPlacemarks = point.kml.wrappedPlacemarks
                },
                point = new Point // Replace by the actual name of this type
                {
                    x = point.point.x,
                    y = point.point.y,
                },
                wkb = point.wkb,
                wkt = point.wkt
            };
        }
