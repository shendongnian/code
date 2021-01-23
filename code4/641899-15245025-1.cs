     for (int i = 0; i < tblRow; i++)
            {
                for (int j = 2; j <= 7; j++)
                {
                    TextBox tb = FindControlRecursive(this, string.Format("txtBoxRow{0}Col{1}", i, j));
                    switch(j)
                    {
                        case 2:
                            TotAmt += Convert.ToDouble(tb.Text);
                            break;
                        case 3:
                            break;
                        default:
                            Label1.Text = Convert.ToString("Value of J : " + j);
                    }
                }
            }
