            // this ext. method will only operate on classes that inherit 
            // from ICollectible and have a public parameterless constructor
            public static int CalculateTotal<T>(this T _collectible)
                where T : ICollectible, new()
            {
                // calculate total
            }
