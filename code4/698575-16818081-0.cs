    public static class UkladSloneczny
    {
        private static Saturn sat;
        public UkladSloneczny(Saturn sat)
        {
            sat = sat;
        }
        public static Saturn saturn
        {
            get { return sat; }
        }
    }
