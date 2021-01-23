    listView1.Columns.Add("test");
    listView1.Items.Add(UserSeesThis);
            public static int[] myArrayOfIntegers = new int[24];
            public static bool TheArrayIsNowReady = false;
            int i;
            int j;
            int k;
            string UserSeesThis = "3";
    
            private void Form1_Load(object sender, EventArgs e)
            {
                TheArrayIsNowReady = true;
                if (TheArrayIsNowReady)
                {
                    for (i = 0; i < 24; i++)
                    {
                        myArrayOfIntegers[i] = i;
                        UserSeesThis = myArrayOfIntegers[i].ToString();
                        listView1.Items.Add(UserSeesThis);
                    }
                }
    
            }
