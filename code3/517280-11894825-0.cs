    private int caseSwitch = 0;
    private void timer1_Tick(object sender, EventArgs e)
    {
        caseSwitch++;
        switch (caseSwitch)
        {
            case 1:
                this.BackColor = Color.Yellow;
                break;
            case 2:
                this.BackColor = Color.Green;
                break;
        }
    
        if (caseSwitch == 2) caseSwitch = 0;
    }
