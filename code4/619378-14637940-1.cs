        public static int[] myArrayOfIntegers = new int[24];
        public static bool TheArrayIsNowReady = false;
        int i, j, k;
        string UserSeesThis = "?";
        ListViewItem item;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            TheArrayIsNowReady = true;
            if (TheArrayIsNowReady)
            {
                for (i = 0; i < 24; i++)
                {
                    myArrayOfIntegers[i] = i;
                    if (i == 0) { item = new ListViewItem(myArrayOfIntegers[0].ToString()); }
                    item.SubItems.Add(myArrayOfIntegers[i].ToString());
                    UserSeesThis = "?";
                }
                listView1.Items.Add(item);
            }
        }
