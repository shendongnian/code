        public abstract class AbstractParam<T> where T : struct
        {
            //....
            public abstract bool TryGet(string input, out T output);
        }
