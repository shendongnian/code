    using MyAssembly; //you can't compile unless MyAssembly is available
    namespace LuaRunner
    {
        class LuaRunner
        {        
            void DoLua()
            {
                using (LuaInterface.Lua lua = new LuaInterface.Lua())
                {
                    lua.DoString("luanet.load_assembly('MyAssembly')");
                    //... do what you want within Lua with MyAssembly
                }
            }
        }
    }
