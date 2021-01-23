    /*
        using System;
        using System.Data;
        using System.Data.Common;
        using Microsoft.Practices.EnterpriseLibrary.Data;
     */
    public IDataReader EmployeesGetAll()
    {
        IDataReader returnReader = null;
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbc = db.GetSqlStringCommand("SELECT * FROM ( SELECT * FROM TEMPLOYEE ) WHERE ROWNUM <= 25");
            returnReader = db.ExecuteReader(dbc);
            return returnReader;
        }
        finally
        {
        }
    }
