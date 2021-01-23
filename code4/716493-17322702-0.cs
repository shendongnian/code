        public static string ArrayToString(string[] array)
        {
            Debug.Assert(array.Length % 2 == 0, "Array is not dividable by two.");
            // Group all coordinates as pairs of two.
            int index = 0;
            var coordinates = from item in array
                              group item by index++ / 2
                                  into pair
                                  select pair;
            // Format each coordinate pair with a comma.
            var formattedCoordinates = coordinates.Select(i => string.Join(",", i));
            // Now concatinate all the pairs with a space.
            return string.Join(" ", formattedCoordinates);
        }
