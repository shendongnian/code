    public static class Cloner
    {
        public static T Clone<T>(this T item)
        {
            FieldInfo[] fis = item.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            object tempMyClass = Activator.CreateInstance(item.GetType());
            foreach (FieldInfo fi in fis)
            {
                if (fi.FieldType.Namespace != item.GetType().Namespace)
                    fi.SetValue(tempMyClass, fi.GetValue(item));
                else
                {
                    object obj = fi.GetValue(item);
                    if (obj != null)
                        fi.SetValue(tempMyClass, obj.Clone());
                }
            }
            return (T)tempMyClass;
        }
    }
