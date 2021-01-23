    class TagModel {
       int[] MyInts { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Tag = new TagModel() { MyInts = new int[] { 1, 93234, 0 }};
    
            var tagModel = (lvi.Tag as TagModel);
            int t = tagModel.MyInts[0];
            Console.WriteLine(t);
        }
    }
