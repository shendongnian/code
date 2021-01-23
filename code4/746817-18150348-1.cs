    DatabaseContext context2 = DatabaseContext.CreateContext(_incompleteConnString + prefix + campaignDBPlatform)
    //Initialize qrepo with the context here??
    Progress prog = new Progress();
    TaskFactory tf = new TaskFactory();
    var parent = tf.StartNew(() =>
      Parallel.ForEach(QuestionsLangConstants.questionLangs.Values, i =>
      {
        try
        {
         qrepo.UploadQuestions(QWorkBook.Worksheets[i.QSheet], i, prog);
        }
        catch (Exception ex)
        {
         MessageBox.Show(ex.Message);
         // Do you really want to continue with the next task after the exception?
        }
       })
    );
    prog.Show();
    var finalTask = parent.ContinueWith(i =>
    {
      UploadedQuestionsRepliesRepository uqrepo = new UploadedQuestionsRepliesRepository(context2);
      UploadedQuestionsReplies UQuestions = new UploadedQuestionsReplies() {
            Id = (int)uqrepo.getNextSeqValue(), 
            FileName = "test", 
            RQType = Questions.QuestionsType.ToString(), 
            TimeStamp = DateTime.Now 
        };
        uqrepo.Insert(UQuestions);
        uqrepo.Save();
        context2.Dispose();
     });
    }
