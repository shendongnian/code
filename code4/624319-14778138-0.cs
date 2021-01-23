        private void Form1_Load(object sender, EventArgs e)
        {
            call(1, new List<long> { 1, 2, 3, 4 });
        }
        void call(Int32 i,List<long> l)
        {
            MessageBox.Show((l[0] + l[1] + l[2] + l[3]).ToString());
        }
           i tried this and working properly so use this code too pass the List object.....
