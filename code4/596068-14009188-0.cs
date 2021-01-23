    protected void Button1_Click(object sender, EventArgs e)
    {
       UC_SurveyControl control = this.Controls[0] as UC_SurveyControl;
       if (control != null)
           string answer = control.GetAnsweredText();
    }
