    int position = EnumUtil.GetEnumIndex<ranks>(ranks.four);
    
    //
    public static class EnumUtil
        {        
                public static int GetEnumIndex<T>(T value)
                {
                    int index = -1;
                    int itemIndex = 0;
                    foreach (T item in Enum.GetValues(typeof(T)).Cast<T>())
                    {
                        if (item.Equals(value))
                        {
                            index = itemIndex + 1;
                            break;
                        }
                        itemIndex ++;
                    }
                    return index;
                }
        }
