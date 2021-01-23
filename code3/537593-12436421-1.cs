        static IEnumerable<string> EnumToEnumerable(Type x)
        {
            if (x.IsEnum)
            {
                var names = Enum.GetValues(x);
                
                for (int i = 0; i < names.Length; i++)
                {
                    yield return string.Format("{0} {1}", (int)names.GetValue(i), names.GetValue(i));
                }
            }
        }
