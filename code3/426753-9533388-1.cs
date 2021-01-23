    public static STDS.UserPresence.user_presenceDataTable GetPresence (int aUserID, DateTime aStart, DateTime aEnd)
    {
      using (MySqlConnection connection = MySQLConnectionBuilder.GetConnection())
      {
          ds = ta.GetPresenceForUserBetweenDates(connection, aUserID, aStart, aEnd);
          return ds;
      }
    }
