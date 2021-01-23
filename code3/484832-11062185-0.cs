    public int HowManyClicked()
            {
                int sum=0;
                foreach (Control cnt in this.Panel2.Controls)
                    if (cnt is Button)
                    {
                        Button btn = (Button)cnt;
                        if (btn.BackColor == Color.Red)
                            sum += 1;
                    }
                return sum;
               }
                
            }
