    using (var attendanceContext = new AttendanceAppContext())
    {
        var compareLogin = attendanceContext.Attendances.FirstOrDefault(u =>
        EntityFunctions.TruncateTime(u.LoginDate) == EntityFunctions.TruncateTime(DateTime.Now) &&
        u.Employee.Username == user.Username);
    }
