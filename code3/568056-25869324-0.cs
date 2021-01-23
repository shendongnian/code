    // If using EntityFramework
    // 1. Setup my params
    var params = new List<SqlParameter>() { 
          new SqlParameter("@UserID", 1),
          new SqlParameter("@Activate", true) // or false
    };
    SqlParameter[] paramArray = params.ToArray();
    // 2. Update the database
    myDbContext.Database.ExecuteSqlCommand("UPDATE webpages_Membership SET IsConfirmed = @Activate WHERE UserId = @UserID", paramArray);
