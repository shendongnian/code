    [DllImport( @"SomeDLL.dll" )]
    static extern void SetAchievementUnlocked( AchievementUnlockCallBack callback );
    public delegate int AchievementUnlockCallBack( AchievementsType id, IntPtr message );
    static AchievementUnlockCallBack mAchievementUnlockCallBack = AchievementUnlocked;
    static int AchievementUnlocked( AchievementsType id, IntPtr pMessage )
    {
        string achievementName = Marshal.PtrToStringAnsi( pMessage );
        DisplayAchievement( achievementName );
        MainWindowHandler.Context.Focus();
        return 1;
    }
