        public static Func<int, bool> t = ReturnTrue;
        public static bool ReturnTrue(int i) 
        {
            return true;
        }
        table.Where(t);
