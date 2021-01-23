    class MyDgv : DataGridView
    {
        public MyDgv()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true); //this is the key
            //and now you can do what you want.
            this.Rows[this.RowCount - 1].Cells[1].Style.BackColor = Color.FromArgb(150, Color.Green);
        }
    }
