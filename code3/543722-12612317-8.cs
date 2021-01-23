        static int Foo(DataContext dc, 
                       string procName, 
                       Dictionary<string, object> paramList)
        {
            StringBuilder command = new StringBuilder("EXECUTE ");
            command.Append(procName);
            int i = 0;
            foreach (string key in paramList.Keys)
            {
                command.AppendFormat(" @{0} = ", key);
                command.Append("{");
                command.Append(i++);
                command.Append("},");
            }
            return dc.ExecuteCommand(command.ToString().TrimEnd(','),  
                                     paramList.Values.ToArray());
        }
