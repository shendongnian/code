    public ActionResult Question(string email,int id)
    {
    
       List<QuestionClass.Tabelfields> fadd=repositary.GetTabelFieldsFromID(id);
        //Do whatever with this
       return View();
    }
