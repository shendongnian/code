    public static class ListExtensions
    {
    	public static List<T> CutOff<T>(this List<T> list, int count)
        {
            var result = list.GetRange(0, count);
            list.RemoveRange(0, count);
            return result;
        }
    }
