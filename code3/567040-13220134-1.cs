     public static IEnumerable<voiture> recup_voitures()
            {
                foreach (voiture v in _arrVCollection)
                {
                    if (v != null)
                        yield return (v);
                }
            }
