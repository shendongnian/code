    public static class MyMath
    {
        private static int counter = 1;
        public static int Random(int max)
        {
            counter++;
            long ticks = DateTime.Now.Ticks;
            int result = Math.Abs((int) (ticks/counter)%max);
            return result;
        }
    }
