            GeoServiceReference.GeocodeServiceClient client = new GeoServiceReference.GeocodeServiceClient();
            var countries = new List<string>();
            for (double lat = 0; lat < 360; lat+=0.1)
                for(double lon = 0; lon < 360; lon+=0.1)
            {
                var result = client.ReverseGeocode(new GeoServiceReference.ReverseGeocodeRequest
                {
                    Location = new GeoServiceReference.Location
                    {
                        Latitude = lat,
                        Longitude = lon
                    }
                });
                if (!countries.Contains(result.Results.First().Address.CountryRegion))
                {
                    Console.WriteLine(result.Results.First().Address.CountryRegion);
                    countries.Add(result.Results.First().Address.CountryRegion);
                }
            }
