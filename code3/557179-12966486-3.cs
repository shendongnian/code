    [HttpPost]
    public void UnfavoriteEvent(int id)
    {
        try
        {
            var rows = _connection.Execute("DELETE UserEvent WHERE UserID = (SELECT up.UserID FROM UserProfile up WHERE up.UserName = @UserName) AND EventID = @EventID",
                new { EventID = id, UserName = User.Identity.Name });
            if (rows != 1)
            {
                return new HttpStatusCodeResult(500, "There was an unknown error updating the database.");
            }
        }
        catch (Exception ex)
        {
            return new HttpStatusCodeResult(500, ex.Message);
        }
    }
