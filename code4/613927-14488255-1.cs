    if (btn1.Text == "X" & btn2.Text == "X" & btn3.Text == "X")
    {
        btn2.BackColor = Color.Green;
        btn3.BackColor = Color.Green;
    }
    else if (btn1.Text == "X" & btn4.Text == "X" & btn7.Text == "X")
    {
        btn4.BackColor = Color.Green;
        btn7.BackColor = Color.Green;
    }
    else
    {
        return/break/continue; // hard to tell which you what as you have a do without a corresponding while
    }
    btn1.BackColor = Color.Green;
    XScore += 1;
    lblPScoreX.Text = XScore.ToString();
    foreach (Button btn in buttonList)
    {
        btn.Enabled = false;
    }
