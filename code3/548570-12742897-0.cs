    IEnumerable<T> getlist<T>(Func<string, string, string, string, string, T> resultor)
    {
        try
        {
            using (ShowDataToClientDataContext c = new ShowDataToClientDataContext())
            {
               var recList = (from record in c.GetTable<T_RECORDSHOW>()
                              where record.RecordStatus.Equals(RecordStatus.Active)
                              select resultor
                              (
                                  (from stu in c.T_STUDENTSHOWs
                                             where stu.Id.Equals(record.StudentId)
                                             select stu.Name).Single().ToString(),
                                  (from t in c.T_TRADESHOWs
                                           where t.Id.Equals(record.TradeId)
                                           select t.Name).Single().ToString(),
                                  (from s in c.T_SESSIONSHOWs
                                               where s.Id.Equals(record.SessionId)
                                               select s.Name).Single().ToString(),
                                  record.Month.ToString(),
                                  record.Attendance.ToString()
                              )).ToList();
               return recList;
            }
        }
        catch
        {
        }
    }
    
