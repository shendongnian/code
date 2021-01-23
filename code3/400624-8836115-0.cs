    string[,] SelectARows(string myConnectionString, string inlist) 
    {
        PrintToErrorFile("Entering SelectARows...");
        string[,] names = new string[1200,4];
        // I don't know what your intent is for myConnection, as you didn't finish your
        // try block, but it will be autodisposed by the using block.  Maybe this isn't your
        // intent, but no matter what myConnect should be disposed since it implements
        // IDisposable
        using(OleDbConnection myConnection = new OleDbConnection(myConnectionString)) {
            // technically, this should be >= 0, but I'm going from  your code
            bool found = myConnectionString.IndexOf("PIOLEDB") > 0;
            string mySelectQuery = null;
            if(found)
                mySelectQuery = "select tag, time, value, status FROM piarchive..pisnapshot WHERE tag in (" + inlist +")";
            // at this point mySelectQuery is either null or the query string.
            // honestly, I would prefer this form, which is equivalent
            string mySelectQuery = found ? "select tag, time, value, status FROM piarchive..pisnapshot WHERE tag in (" + inlist +")"
                                         : null;
        }
    }
