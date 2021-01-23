        // Counts how many different members exist in the enum type
        public int countElements<T>()
        {
            if(!typeof(T).IsEnum)
                throw new InvalidOperationException("T must be an Enum");
            return Enum.GetNames(typeof(T)).Length;
        }
        // Call above function
        public void foo()
        {
            int num = countElements<ELEMENT>();
        }
