    public static void PopulateExamList(MarkEditViewModel model,
        List<Exam> examList)
    {
        model.ExamList = new SelectList(examList, "Id", "ExamName");
    }
