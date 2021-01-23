    public IQueryable result(string username, string exam)
    {
        return from result in idb.User_Exam_Question
               where (result.User_Tbl_email == username && result.Exam_Tbl_ID == Convert.ToInt32(exam))
               group result by result.category_tbl_ID into cat
               select new
               {
                   CatCount = cat.Count()
               } 
    }
