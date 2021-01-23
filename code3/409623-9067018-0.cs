    class Program
    {
        static void Main()
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Tag = new object[] { 1, 93234, 0 };
    
            object[] objs = (lvi.Tag as object[]);
            int t = (int)objs[0];
            Console.WriteLine(t);
        }
    }
