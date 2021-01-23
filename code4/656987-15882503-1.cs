    public partial class Implications
    {
        internal static bool CheckImplies<T>(T lhs, T rhs)
        {
            return Implies((dynamic)lhs, (dynamic)rhs);
        }
        public static bool Implies(int lhs, int rhs)
        {
            return lhs == (lhs & rhs);
        }
        // your other implies thingies implement this same partial class
    }
    public static partial class LogicExtensions
    {
        public static bool Implies<T>(this T premise, T conclusion, Paradox<T> predicate = null)
        {
            if (null == predicate)
                return conclusion.Infers(premise, Implies);
            if (Infers != predicate)
                return predicate(premise, conclusion);
            return Implications.CheckImplies(premise, conclusion);
        }
        public static bool Infers<T>(this T premise, T conclusion, Paradox<T> predicate = null)
        {
            if (null == predicate)
                return premise.Implies(conclusion, Infers);
            if (Implies != predicate)
                return predicate(premise, conclusion);
            return Implications.CheckImplies(premise, conclusion);
        }
    }
