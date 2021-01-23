        private const string base36Characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string toBase36(long x)
        {
            String alpha ="";
            while(x>0){
                alpha = base36Characters[(int) (x % 36)] + alpha;
                x /= 36;
            }
            return alpha.ToLower();
        }
