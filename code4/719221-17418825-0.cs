    protected void cell_Color()
    {
        string sAplus = "A+";
        string sA = "A";
        string sB = "B";
        string sC = "C";
        string sD = "D";
        string sF = "F";
        for (int r = 0; r < gv.Rows.Count; r++)
        {
            for (int c = 1; c < gv.Rows[r].Cells.Count; c++)
            {
                string grade = gv.Rows[r].Cells[c].Text;
                    bool bAplus = grade.Contains(sAplus);
                    bool bA = grade.Contains(sA);
                    bool bB = grade.Contains(sB);
                    bool bC = grade.Contains(sC);
                    bool bD = grade.Contains(sD);
                    bool bF = grade.Contains(sF);
                    if (bAplus == true)
                        gv.Rows[r].Cells[c].BackColor = Color.FromArgb(0, 255, 0);
                    if (bA == true)
                        gv.Rows[r].Cells[c].BackColor = Color.FromArgb(100, 255, 100);
                    if (bB == true)
                        gv.Rows[r].Cells[c].BackColor = Color.FromArgb(0, 0, 255);
                    if (bC == true)
                        gv.Rows[r].Cells[c].BackColor = Color.FromArgb(255, 255, 25);
                    if (bD == true)
                        gv.Rows[r].Cells[c].BackColor = Color.FromArgb(128, 64, 0);
                    if (bF == true)
                        gv.Rows[r].Cells[c].BackColor = Color.FromArgb(255, 0, 0);
                }
            }
        }
    }
