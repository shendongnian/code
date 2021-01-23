        for (int i = 1; i <= 3; i++)
        {
            count = chk.GetCount(i);
            if (count == -1)
            {
                switch (i)
                {
                    case 1:
                        btnDept1.Visible = false;
                        break;
                    case 2:
                        btnDept2.Visible = false;
                        break;
                    case 3:
                        btnDept3.Visible = false;
                        break;
                }
            }
            else
            {
                switch(i)
                {
                    case 1:
                        btnDept1.Text = "Next dep1[" + count.ToString() + "]";
                        if (count == 0)
                            btnDept1.Enabled = false;
                        break;
                    case 2:
                        btnDept1.Text = "Next dep1[" + count.ToString() + "]";
                        if (count == 0)
                            btnDept1.Enabled = false;
                        break;
                    case 3:
                        btnDept1.Text = "Next dep1[" + count.ToString() + "]";
                        if (count == 0)
                            btnDept1.Enabled = false;
                        break;
                }
            }
        }
