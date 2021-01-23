            int fClr = 0;
    private void btnClr_Click(object sender, EventArgs e)
        {
            while (Visible)
            {
                if (fClr == 0)
                {
                    fClr++;
                    for (int nBackClr = 0; nBackClr < 255 && Visible; nBackClr++)
                    {
                        this.BackColor = Color.FromArgb(nBackClr, 255 - nBackClr, nBackClr);
                        Application.DoEvents();
                        Thread.Sleep(2);
                    }
                    for (int z = 255; z >= 0 && Visible; z--)
                    {
                        this.BackColor = Color.FromArgb(z, 255 - z, z);
                        Application.DoEvents();
                        Thread.Sleep(2);
                    }
                }
                else
                {
                    fClr--;
                    this.BackColor = Color.MediumBlue;
                    Application.DoEvents();
                    Thread.Sleep(1);
                }
            }
        }
 
