    public int Compare(object x, object y)
            {
                int CompareResult;
                ListViewItem a = (ListViewItem)x;
                ListViewItem b = (ListViewItem)y;
    
                Color red = Color.FromArgb(200, 0, 0);
                
                int textCompare = a.Text.CompareTo(b.Text);
                bool bothRed = a.BackColor == red && b.BackColor == red;
                bool bothOtherColor = a.BackColor != red && b.BackColor != red;
    
                return bothRed || bothOtherColor ? textCompare : b.BackColor == red ? 1 : -1;
    }
