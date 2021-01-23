    public ActionResult ajaxUpdate()
            {
                //open connection
                dbcontext db = new dbcontext();
                db.Connection.Open();
    
                // get the last updated record in the database.
                var entry = db.Entry.OrderByDecending(m=> m.LastUpdatedDate).FirstOrDefault();
    
                //clean up
                db.Connection.Close();
                db.Dispose();
    
                //return -1 as error
                if(entry == null){
    
                    return Json(-1,JsonRequestBehavior.AllowGet);
    
                }
    
                // get current number of people in queue
                Int32 numberOfPeople = entry.QueueNumber;
    
                TimeSpan span = DateTime.Now.Subtract(entry.LastUpdatedDate);
    
                if(span.Minutes >= 20){
    
                    // if 20 mins have passed assume a person has been completed since manual update
                    numberOfPeople--;
    
                }
    
                //this returns a number, alternatively you can return a Partial
                return Json(numberOfPeople, JsonRequestBehavior.AllowGet);
            }
