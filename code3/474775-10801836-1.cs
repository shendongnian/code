    protected void AnswerChanged(object sender, EventArgs e)
    {
        RadioButton rbAnswer = (RadioButton)sender;
        if (rbAnswer.Checked)
        { 
            string panelID = rbAnswer.GroupName + "Panel";
            if (rbAnswer.Text == "Yes")
                    rbAnswer.Parent.FindControl(panelID).Visible = true;
             else
                    rbAnswer.Parent.FindControl(panelID).Visible = false;
        }
    }
