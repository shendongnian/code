    public bool TryGet(int userId, out User user) {
        try {
            var conn = CreateDbConnection();
            var myUser = GetUser(userId, conn);
            user = myUser;
            return true;
        }
        catch {
            return false;
        }
    }
