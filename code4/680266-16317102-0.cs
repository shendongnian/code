    public static async Task TestLevelAsync()
    {
        var UserSetting = await Task.Run(async () =>
        {
            return await database.GetSettingByName("test");
        });
        User objuser = new User();
        objuser.usersetting = UserSetting.Value;
    }
