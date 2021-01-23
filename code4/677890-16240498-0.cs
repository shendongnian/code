        public static class PersonExtensions
        {
            public static bool GotLegs(this IPerson person)
            {
                return true;
            }
        }
    In that case, `IPerson` shouldn't define `GotLegs` itself.
