     private void ProcessTable(LuaTable t, int depth)
            {
                depth++;
                Console.WriteLine(new String('=', 5 * (5 - depth)));   // Creates breaks between the items
                foreach (DictionaryEntry d in t)
                {
                    if (d.Value.GetType() == typeof(LuaTable))
                    {
                        ProcessTable((LuaTable)d.Value, depth);
                    }
                    else
                    {
                        Console.WriteLine(String.Format("{0}={1}", d.Key, d.Value));
                    }
                }
                Console.WriteLine(new String('=',5 * (5-depth)));
            }
