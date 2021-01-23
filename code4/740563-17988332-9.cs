    public static class Program
    {
       
        static void Main(string[] args)
        {       
            List<int> numList=new List<int>(){1,2,2,2,4,5,3,2};
            numList = numList.RemoveSequentialRepeats();
        }
        public static List<T> RemoveSequentialRepeats<T>(this List<T> p_input)
        {
            var result = new List<T> { p_input.First() };
            result.AddRange(p_input.Where(p_element => !result.Last().Equals(p_element)));
            return result;
        }
    }
