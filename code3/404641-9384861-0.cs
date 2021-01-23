    public static IEnumerable<string> GetGlobalsFromFile(string fileName)
    {
         using (Lua lua = new Lua())
         {
              lua.DoFile(filename);
              foreach(string global in lua.Globals)
                   yeld return global;
         }
    }
