        IEnumerable<string> toEnumerable(Type x)
        {
            if (x.GetType() == typeof(Enum))
            {
                var names = Enum.GetNames(x);
                var values = Enum.GetValues(x);
                for (int i = 0; i < names.Length; i++)
                {
                    yield return string.Format("{0} {1}", names[i], values[i]);
                }
            }
        }
