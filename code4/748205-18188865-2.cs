        public Color color1;
        public Color color2;
        public int rowhandle;
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle == rowhandle)
                {
                    if (color1 != null && color2 != null)
                    {
                        e.Appearance.BackColor = color1;
                        e.Appearance.BackColor2 = color2;
                    }
                }
            }
            catch
            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            color1 = Color.BurlyWood;
            color2 = Color.DarkOrchid;
            rowhandle = gridView1.FocusedRowHandle;
            gridView1.RefreshRow(rowhandle);
        }
