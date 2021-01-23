    public static class ExtensionClass
    {
        public static void Move<T>(this List<T> list, int index1, bool moveDown = true)
        {
            if (moveDown)
            {
                T temp = list[index1];
                list[index1] = list[index1 + 1];
                list[index1 + 1] = temp;
            }
            else
            {
                T temp = list[index1];
                list[index1] = list[index1 - 1];
                list[index1 - 1] = temp;
    
            }
        }
    }
