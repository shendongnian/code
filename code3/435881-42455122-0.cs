     public static List<T> ObtenerControles<T>(DependencyObject parent)
        where T : DependencyObject
        {
            List<T> result = new List<T>();           
            if (parent != null)
            {
                foreach (var child in LogicalTreeHelper.GetChildren(parent))
                {                   
                    var childType = child as T;
                    if (childType != null)
                    {
                        result.Add((T)child);
                    }
                    foreach (var other in ObtenerControles<T>(child as DependencyObject))
                    {
                        result.Add(other);
                    }
                }
            }
            return result;
        }
