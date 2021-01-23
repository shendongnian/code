        public static bool Implies<T>(this T premise, T conclusion)
        {
            return Implications.CheckImplies(premise, conclusion);
        }
        public static bool Infers<T>(this T premise, T conclusion)
        {
            return Implications.CheckImplies(conclusion, premise);
        }
