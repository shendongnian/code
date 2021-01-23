    public sealed class HTDB_Tables
    {
        // this is the class that will hold all Sql server - tables Names
        public const string TblTime = "tblTime";
    }
     // the class for Stored Procedures Paramaters - (for each stored procedure)
    public sealed class HTDB_SPs
    {
        // for example this is one of the stored procedures
        public sealed class GetTimesWithCustomerNames
        {
            public static List<SqlParameter> SqlParlst(string SlctdUserID, string SlctdMonth, string SlctdYear, string SlctdEventID)
            {
                SqlParameter Userid = new SqlParameter( UserIdParName, SlctdUserID);
                SqlParameter Month = new SqlParameter(MonthParName, SlctdMonth);
                SqlParameter Year = new SqlParameter(YearParName, SlctdYear);
                SqlParameter EventId = new SqlParameter(EventIdarName, SlctdEventId);
                List<SqlParameter> RetSqlParLst  = new List<SqlParameter>();
                retSqlParLst.Add(UserId);
                retSqlParLst.Add(Month);
                retSqlParLst.Add(Year);
                retSqlParLst.Add(EventId);
                return retSqlParLst;
            }
            const string UserIdParName = "@userId",
                         MonthParName = "@month",
                         YearParName = "@year",
                         EventIParName = "@eventId";
      
        }
    }
    // a numeric value that's used to reference the table
    // the id is passed as a parameter to a javascript-Jquery Update function 
    // through the textbox control - "textchange event" - attribute,
    // as reference to which table to send the updated data .
    // then it is proccessed  in code behind  as table id  inside the application 
    // via a switch on the parameter sent by Jquery-ajax function
    public sealed class HTDB_tblIDs
    {
        public const int tblTime = 1;
       //this is only an example , for one of tables 
       //as it requierd that all sql database tables(that i want to work with this project)
       // will be added here too
       // this could be done via using code smith or through few simple 
      // steps you could do it via simple C# method that will list all your 
      // database tables names etc'
    }
