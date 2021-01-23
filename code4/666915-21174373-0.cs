           Student stud = null;
            using (SchoolDBContext ctx = new SchoolDBContext())
            {
                stud = (from s in ctx.Students
                        where s.StudentName == "Student1"
                            select s).FirstOrDefault();
            }
            using (SchoolDBContext newCtx = new SchoolDBContext())
            {
                newCtx.Students.Attach(stud);
                newCtx.Students.DeleteObject(stud);
                //you can use ObjectStateManager also
                //newCtx.ObjectStateManager.ChangeObjectState(stud, 
                                        System.Data.EntityState.Deleted);
                int num = newCtx.SaveChanges();
            }
