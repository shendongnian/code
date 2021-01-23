    Session s = new Session();
    s.Id = r.Read<byte[]>("", null);
    s.UserId = (int)r.Read<int>("");
    s.LoginTime = (DateTime)r.Read<DateTime>("");
    s.LogoutTime = r.Read("", default(DateTime?));
    s.MachineFingerprint = r.Read<string>("", null);
