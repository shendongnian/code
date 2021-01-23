         public bool CallSp(string command, params object[] parameters)
            {
                int i;
                string com = command + " ";
                for (i = 0; i < parameters.Count() - 1; i++)
                {
                    com += string.Format("{{0}} ,", i);
                }
                com += string.Format("{{0}}", i);
    
                //ctx is the datacontext
                //EF5
                ctx.Database.ExecuteSqlCommand(com, parameters);
                return true;
            }
            CallSp("exec SP", p1, p2, p3,...);
