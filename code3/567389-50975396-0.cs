    private void DataGridView1_Scroll(object sender, ScrollEventArgs e)
    {
        DataGridView2.FirstDisplayedScrollingRowIndex =
            DataGridView1.FirstDisplayedScrollingRowIndex;
    }
    private void DataGridView2_Scroll(object sender, ScrollEventArgs e)
    {
        DataGridView1.FirstDisplayedScrollingRowIndex =
            DataGridView2.FirstDisplayedScrollingRowIndex;
    }
