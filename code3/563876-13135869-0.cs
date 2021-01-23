    public class CusComparer: IComparer
    {
        public int Compare(object x, object y)
        {
            return int.Parse((x as string).Substring(4)) - int.Parse((y as string).Substring(4));
        }
    }
