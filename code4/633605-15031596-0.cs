        string testLength = "1";
        private void DataSheets_Load(object sender, EventArgs e) //DataGridView, 2 columns
        {
            clmData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Data.DefaultCellStyle.Font = new Font("Courier", 8);
            RunWidth();
        }
        void RunWidth()
        {
            int l1 = len(testLength);
            int l2 = len(testLength + testLength);
            int perChar = l2 - l1;
            int pad = l1 - perChar;
            int s7 = pad + (perChar * 75);
            int s5 = pad + (perChar * 50);
            Data.Columns[0].Width = s7;
            Data.Columns[1].Width = s5;
        }
        public int len(string text)
        {
            Size te = TextRenderer.MeasureText(text, new Font("Courier", 8));
            return te.Width;
        }
