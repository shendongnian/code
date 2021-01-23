        HuntingDate huntingDate = new HuntingDate();
    with this you have to consider where you want to have access to it. If you need a global accessible instance you could initialise the class as a global scope level, or consider using a [static class][5] (though it should be noted that these values would be persisted across the whole application:
        public static class HuntingDate 
        {
            public static string Something;
        }
