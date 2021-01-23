     public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
            {
                return enumerable == null || !enumerable.Any();
            }
     public static List<T> IsNullThenNew<T>(this IEnumerable<T> t)
            {
                if (!IsNullOrEmpty<T>(t))
                {
                    return t.ToList();
                }
                else
                {
                    Type genericListType = typeof(List<>);
                    Type listType = genericListType.MakeGenericType(t.GetType());
                    object listInstance = Activator.CreateInstance(listType);
                    return (List<T>)listInstance;
                }//end if-else
            }
