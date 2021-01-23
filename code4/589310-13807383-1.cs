    Control answerPanel = Page.FindControl("AnswerPanelID");
    foreach( Control childControl in answerPanel.Controls )
    {
        if( childControl is TextBox )
        {
            //Retrieve and store value from childControl.Text
        }
    }
