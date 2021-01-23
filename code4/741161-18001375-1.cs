    void Main()
    {
        IsNormal(GameFlow.Normal).Dump();// True
        IsNormal(GameFlow.NormalNoMove).Dump();// True
        IsNormal(GameFlow.Paused).Dump();// False
        IsNormal(GameFlow.Battle).Dump();// False
    
        IsNormal(GameFlow.Normal | GameFlow.Paused).Dump();// True
        IsNormal(GameFlow.NormalNoMove  | GameFlow.Battle).Dump();// True
        IsNormal(GameFlow.Paused | GameFlow.Battle).Dump();// False
        IsNormal(GameFlow.Battle | GameFlow.Normal).Dump();// True
    
    }
