        protected void UpdateQuestionName_Click(object sender, EventArgs e)
        {
            int QuestionnaireId = (int)Session["qID"];
            GetData = new OsqarSQL();
            
            //get the button that caused the event
            Button btn = (sender as Button);
            if (btn != null)
            {
                    //here's you question text box if you need it
                    TextBox questionTextBox = (btn.Parent.FindControl("QuestionName") as TextBox);
    
                    // Update question name
                    GetData.InsertQuestions(questionTextBox.Text, QuestionnaireId);
                    
                    
                    
                    //and in case you want more of the associated controls
                    //here's your data list with text boxes
                    DataList answersDataList = (btn.Parent.FindControl("nestedDataList") as DataList);
                    //and if answersDataList != null, you can use answersDataList.Controls to access the child controls, where answer text boxes are
            }
            
        } // End NewQNRButton_Click
