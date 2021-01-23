            var semaphore = SemaphoreRepository.FetchMySemaphore(myContext);
            var past = DateTime.UtcNow.AddHours(-1);
            //check lock, break if in use.  Ignor if the lock is stale.
            if (semaphore == null || (semaphore.InUse && (semaphore.ModifiedDate.HasValue && semaphore.ModifiedDate > past)))
            {
                return;
            }
            //Update semaphore to hold lock
            try
            {
                semaphore.InUse = true;
                semaphore.OverrideAuditing = true;
                semaphore.ModifiedDate = DateTime.UtcNow;
                myContext.Entry(semaphore).State = EntityState.Modified;
                myContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                //concurrency exception handeling another thread beat us in the race.  exit
                return;
            }
            catch (DBConcurrencyException)
            {
                return;
            }
            //Do work here ...  
