      public static bool EqualsObject<T>(this T t1, T t2) where T : class
            {
                var p1 = t1.GetType().Fields();
                var p2 = t2.GetType().Fields();
                for (int j = 0; j < p1.Length; j++)
                {
                    var x = p1[j].GetValue(t1, null);
                    var y = p2[j].GetValue(t2, null);
                    if (x == null && y == null)
                        continue;
                    if (x != null && y == null)
                        return false;
                    if (x == null)
                        return false;
                    if (!x.Equals(y))
                    {
                        return false;
                    }
                }
                return true;
            }
