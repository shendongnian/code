    public class Caclulator<T> where T : Numeric<T>
    {
        public static T AddValues(params T[] values)
        {
            T sum = default(T);
            if (values != null) {
                for (int i = 0; i < values.Length; i++) {
                    sum += values[i];
                }
            }
            return sum;
        }
    }
