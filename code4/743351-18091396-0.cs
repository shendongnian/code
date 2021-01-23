    enum SchrodingersCoin
    {
        Heads,
        Tails,
    }
    class Likelihood<T>
    {
        public static List<double> likelihoods = new List<double>();
        static Likelihood()
        {
            // This code is equal likelihood of each value
            int length = Enum.GetValues(typeof(T)).Length;
            double likelihood = 1.0 / length;
            for (int i=0; i<length; i++)
            {
                likelihoods.Add(likelihood);
            }
        }
    }
