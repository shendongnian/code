    public static void Delete(Testcase tc)
    {
    	var db = ObjectContextPerHttpRequest.Context;
    
    	db.DeleteObject((from p in db.TestcaseSet
    					 where p.Id == tc.Id
    					 select p).Single());
    	db.SaveChanges();
    }
