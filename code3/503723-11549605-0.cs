    ConcurrentBag<Result> results = new ConcurrentBag<Result>();
    
    Parallel.Invoke(
                    () => {
                        var db = new DatabaseEntities();  
                        Result result1 = db.StoredProcudure1();
                        results.Add(result1);
                    }
                    () => {
                        var db = new DatabaseEntities();  
                        Result result2 = db.StoredProcudure2();
                        results.Add(result2);
                    }
                    () => {
                        var db = new DatabaseEntities();  
                        Result result3 = db.StoredProcudure3();
                        results.Add(result3);
                    }
    );
    
    return results;
