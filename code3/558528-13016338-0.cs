     public List<usp_GetPeople_Result> usp_GetPeople2()
        {
            using (var db = new demoEntities())
            {
                return db.usp_GetPeople().ToList();
            }
        }
