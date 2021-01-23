    public static class ThingFactory
    {
        public interface IThing {}
        public enum ThingType
        {
            Thing,
            DerivedThing
        }
        public static IThing CreateThing(ThingType type)
        {
            switch(type)
            {
                case ThingType.DerivedThing:
                    return new DerivedThing();
                default:
                    return new Thing();
            }
        }
        private class Thing : IThing {}
        private class DerivedThing : Thing {}
    }
