    public int Compare ( object x, object y )
    {
    	int CompareResult;
    	ListViewItem a = ( ListViewItem ) x;
    	ListViewItem b = ( ListViewItem ) y;
    
        Color red = Color.FromArgb(200, 0, 0);
    
        if (a.BackColor == red)
        {
            if (b.BackColor == red)
            {
                return a.Text.CompareTo(b.Text);
            }
            else
            {
                return -1;
            }
        }
        else
        {
            if (b.BackColor == red)
            {
                return 1;
            }
            else
            {
                if (a.ForeColor == red)
                {
                    if (b.ForeColor == red)
                    {
                        return a.Text.CompareTo(b.Text);
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    if (b.ForeColor == red)
                    {
                        return 1;
                    }
                    else
                    {
                        return a.Text.CompareTo(b.Text);
                    }
                }
            }
        }
    }
