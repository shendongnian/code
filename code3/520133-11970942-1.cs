        public static bool IsDefault(dynamic input)
        {
            if (input == null)
            {
                return true;
            }
            else if (input.GetType().IsValueType)
            {
                return input == Activator.CreateInstance(input.GetType());
            }
            else
            {
                return false;
            }
        }
