       bool TestWin(Button btnA, Button btnB, button btnC)
       {
               if (btnA.Text == "X" & btnB.Text == "X" & btnC.Text == "X")
               {
                        btnA.BackColor = Color.Green;
                        btnB.BackColor = Color.Green;
                        btnC.BackColor = Color.Green;
                        XScore += 1;
                        lblPScoreX.Text = XScore.ToString();
                        foreach (Button btn in buttonList)
                        {
                             btn.Enabled = false;
                        }
                        return true;
               }
               return false;
         }
         if (!TestWin(btn1, btn2, btn3))
               TestWin(btn1, btn4, btn7);
