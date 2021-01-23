    // get records from file
    
    foreach record in file
    {
       dbRecord = _db.Find(record)
       
       if(dbRecord != null)
       {
            if(logicCheck(dbRecord))
            {
                _db.Update(dbRecord)
            }
    	    else if(logicCheck2(dbRecord))
    	    { 
    	        _db.Update3(dbRecord)
    	    }
    	    else
    	    {
    	        // do some more logic 
            }
    	    if(otherCheck(dbRecord))
    	    {
    	        _db.Update2(dbRecord)
    	    }
       }
       else
       {
          // do some more logic checks
          _db.Insert(record)
       }
    }
