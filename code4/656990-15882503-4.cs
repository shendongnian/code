        public static T Optimize<T>(this Not<Not<T>> var)
        {
            return Optimize(var.not.not);
        }
        public static T Optimize<T>(this T var)
        {
            return var;
        }
