     public ObjectResult<usp_GetPeople_Result> usp_GetPeople3()
        {
            using (var db = new demoEntities())
            {
                return db.usp_GetPeople();
            }
        }
