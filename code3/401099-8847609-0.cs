        public static Func<T1, T2> CreateMapping<T1, T2>()
            where T2 : new()
        {
            var typeOfSource = typeof(T1);
            var typeOfDestination = typeof(T2);
            // use reflection to get a list of the properties on the source and destination types
            var sourceProperties = typeOfSource.GetProperties();
            var destinationProperties = typeOfDestination.GetProperties();
            // join the source properties with the destination properties based on name
            var properties = from sourceProperty in sourceProperties
                             join destinationProperty in destinationProperties
                             on sourceProperty.Name equals destinationProperty.Name
                             select new { SourceProperty = sourceProperty, DestinationProperty = destinationProperty };
            return (x) =>
            {
                var y = new T2();
                foreach (var property in properties)
                {
                    var value = property.SourceProperty.GetValue(x, null);
                    property.DestinationProperty.SetValue(y, value, null);
                }
                return y;
            };
        }
        public static void Fill<T1, T2>(List<T1> Source, List<T2> Destination)
            where T2 : new()
        {
            Destination.AddRange(Source.Select(CreateMapping<T1, T2>()));
        }
