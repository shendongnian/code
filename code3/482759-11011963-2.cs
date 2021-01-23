    // THIS PART ONLY WRITTEN ONCE
    public class Database
    {
        // This is the template method - it only needs to be written once, so the prolog and epilog only exist in this method...
        public static IDatabaseError ExecuteQuery(Action<ISession> queryCallback)
        {
            try
            {
                //Initialize session to database
            }
            catch (Exception)
            {
                // return error with description for this step
            }
            try
            {
                // Try to create 'transaction' object
            }
            catch(Exception)
            {
                // return error with description about this step
            }
            try
            {       
                // Execute call to database with session and transaction object
                //
                // Actually in all function only this section of the code is different
                //
                var session = the session which was set up at the start of this method...
                queryCallback(session);
            }
            catch(Exception)
            {
                // Transaction object rollback
                // Return error with description for this step
            }
            finally
            {
                // Close session to database
            }
            return everything-is-ok
        }
    }
