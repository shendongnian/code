    try
    {
    	new LuaInterface.Lua().DoString("die");
    }
    catch (LuaException ex)
    {
    	Console.WriteLine(ex.Message);
    }
