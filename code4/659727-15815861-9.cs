    var ExtendedTotalMinutes = 2 * 60; // hours * minutes
    public override void ResetItemTimeout2(HttpContext context, string id)
    {
        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = 
            new OdbcCommand("UPDATE Sessions SET Expires = ? " +
                "WHERE SessionId = ? AND ApplicationName = ?", conn);
        cmd.Parameters.Add("@Expires", OdbcType.DateTime).Value 
            = DateTime.Now.AddMinutes(ExtendedTotalMinutes); // IMPORTANT!! Set your total expiration time.
        cmd.Parameters.Add("@SessionId", OdbcType.VarChar, 80).Value = id;
        cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;
        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch (OdbcException e)
        {
            if (WriteExceptionsToEventLog)
            {
                WriteToEventLog(e, "ResetItemTimeout");
                throw new ProviderException(exceptionMessage);
            }
            else
                throw e;
        }
        finally
        {
            conn.Close();
        }
    }
