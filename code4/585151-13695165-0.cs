        public static class Extensions
        {
            public static string GetField(this HangingArtBundle hab, string property)
            {
                if (hab.GetType().GetProperties().Any(p => p.Name.Equals(property)))
                {
                    return (string)hab.GetType().GetProperty(property).GetValue(hab, null);
                }
                return string.Empty;
            }
        }
