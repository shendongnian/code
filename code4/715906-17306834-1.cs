    typedef int (*AchievementUnlockCallBack)(AchievementsType pType, char* pMessage);
    AchievementUnlockCallBack globalCallback = NULL;
    __declspec(dllexport) void SetAchievementUnlocked( AchievementUnlockCallBack callback )
    {
        globalCallback = callback
    }
