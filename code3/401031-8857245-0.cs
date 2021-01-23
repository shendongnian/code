    protected void UpdateQuestionName_Click(object sender, EventArgs e)
    {
        int QuestionnaireId = (int)Session["qID"];
        GetData = new OsqarSQL();
        // Update question name
        GetData.InsertQuestions(QuestionName.Text, QuestionnaireId);
        
        
        
        //get the button that caused the event
        Button btn = (sender as Button);
        if (btn != null)
        {
                //here's you question text box if you need it
                TextBox questionTextBox = (btn.Parent.FindControl("QuestionName") as TextBox);
                //here's your data list with text boxes
                DataList answersDataList = (btn.Parent.FindControl("nestedDataList") as DataList);
                //and if answersDataList != null, you can use answersDataList.Controls to access the child controls, where answer text boxes are
        }
        
    } // End NewQNRButton_Click
