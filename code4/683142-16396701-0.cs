        void Insert(params string[] names)
        {
            if (names.Length % 2 != 0) throw new ArgumentException();
            for (int i = 0; i < names.Length; i += 2)
            {
                string name = names[i];
                string surname = names[i + 1];
                // use it
            }
        }
