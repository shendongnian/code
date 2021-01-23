    public static bool Insert_Question_Answer(List<QuestionClass.Tabelfields> AllList)
    {
          List<Feedback> fadd = new List<Feedback>();
            for (int i = 0; i < AllList.Count; i++)
            {
                Feedback f = new Feedback();
                f.Email = AllList[i].Email;
                f.QuestionID = AllList[i].QuestionID;
                f.Answer = AllList[i].SelectedOption;
                fadd.Add(f);
            }
            context.Feedbacks.InsertAllOnSubmit(fadd);
            context.SubmitChanges();
        return true;            
    }
