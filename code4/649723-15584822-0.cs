    public void ShowTable(LuaTable t)
    {
        LuaTable t1 = t[1];
        Console.WriteLine(t1[1]);   // should display 888
        t.Dispose();                  // Don't forget to Dispose the table sent from Lua to C#, or memory leak happens!
    }
