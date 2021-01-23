     A obj = new A();
            for (int i = 1; i < 4; i++)
            {
                FieldInfo field = obj.GetType().GetField(String.Format("field{0}", i), BindingFlags.NonPublic | BindingFlags.Instance);
                if (null != field)
                {
                    field.SetValue(obj, i);
                }
            }
