      MyDBDataContext DB = new MyDBDataContext();
      using (TransactionScope ts = new TransactionScope())
      {
          SurveyClient objMaster = new SurveyClient();
          objMaster.SurveyID = int.Parse(dtQuestions.Rows[0]["SurveyID"].ToString());
          MembershipUser myObject = Membership.GetUser();
          myObject.ProviderUserKey.ToString();
          objMaster.UserID = Guid.Parse(myObject.ProviderUserKey.ToString());  //Guid.Parse("993a109d-a0c7-4946-a8da-99fb594f3ce2");// current userID                  
          objMaster.SurveyDate = DateTime.Now;                  DB.SurveyClients.InsertOnSubmit(objMaster);
          DB.SubmitChanges();
          foreach (DataRow dr in dtQuestions.Rows)                 
          {
                int currQueScore = GetAnswerScore(dr["AnswerType"].ToString().Trim(), dr["ClientAnswerValue"].ToString().Trim()); 
                dr["ClientAnswerScore"] = currQueScore;
                myScore += currQueScore;  
                SurveyClientAnswer objDetail = new SurveyClientAnswer();                      
                objDetail.SurveyClientID = objMaster.SurveyClientID;   
                objDetail.QuestionID = int.Parse(dr["QuestionID"].ToString()); 
                objDetail.Answer = dr["ClientAnswerValue"].ToString(); 
                objDetail.Score = int.Parse(dr["ClientAnswerScore"].ToString());       
                DB.SurveyClientAnswers.InsertOnSubmit(objDetail);
                // DB.SubmitChanges(); //no need for this one
          }
          objMaster.FinalScore = myScore;
          DB.SubmitChanges();      
          ts.Complete();
      }
