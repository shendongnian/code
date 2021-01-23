    Class Manager()
    public static GameLocalPlayer LocalPlayer { get; set; }
    LuaInterace lua = new LuaInterface;
    lua["variablename"]=Manager.LocalPlayer;  
    ---lua----
    variablename.Health;
    variablename:AttackTarget(target);
