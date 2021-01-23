    public class MyCompare : IComparer<string> 
    { 
        public int Compare(string x, string y) 
        { 
            //get line_acc_ar[4] part from strings x and y
            string[] Separator = new string[] { "__" };
            string partX = x.Split(Separator, StringSplitOptions.None)[2];
            string partY = y.Split(Separator, StringSplitOptions.None)[2];
            int intPartX = int.Parse(partX );
            int inrPartY = int.Parse(partY );
            return intPartX.CompareTo(inrPartY)
 
        } 
    }
    list_lines_silver_count.OrderBy(a => a, new MyCompare());
