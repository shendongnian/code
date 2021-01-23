    public string encode(Type containerClass, string SSRVassemblyName)
        {
            string proTSQLcommand="";
            MethodInfo[] methodName = containerClass.GetMethods();
            foreach (MethodInfo method in methodName)
            {
                proTSQLcommand += "CREATE FUNCTION ";
                if (method.ReflectedType.IsPublic)
                {
                    bool hasParams = false;
                    proTSQLcommand += method.Name +"(";
                    ParameterInfo[] curmethodParams = method.GetParameters();
                    if (curmethodParams.Length > 0)
                        for (int i = 0; i < curmethodParams.Length; i++)
                        {
                            proTSQLcommand +=(hasParams?",":"")+ String.Format("@{0} {1}",curmethodParams[i].Name,CLRtypeTranscoder(curmethodParams[i].ParameterType.Name)) ;
                            hasParams = true;
                        }
                    proTSQLcommand += (hasParams ? "," : "") + String.Format("@RetVal {0} OUT", CLRtypeTranscoder(method.ReturnType.Name));
                }
                proTSQLcommand += "RETURNS INT ";
                //watch this! the assembly name you have to use is the one of SSRV, to reference the one of the CLR library you have to use square brackets as follows
                proTSQLcommand += String.Format("AS EXTERNAL NAME {0}.[{1}.{2}].{3}; GO ",SSRVassemblyName, GetAssemblyName(containerClass.Name),containerClass.Name,method.Name);
            }
            return proTSQLcommand;
        }
        public string CLRtypeTranscoder(string CLRtype)
        { //required as the mapping of CLR type depends on the edition of SQL SERVER you are using
            switch (CLRtype.ToUpper())
            {
                case "STRING":
                    return "VARCHAR(MAX)";
                case "INT":
                    return "INT";
            }
            throw new   ArgumentOutOfRangeException();
        }
        public static String GetAssemblyName(String typeName)
        {
            foreach (Assembly currentassemblAssy in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type t = currentassemblAssy.GetType(typeName, false, true);
                if (t != null) { return currentassemblAssy.FullName; }
            }
            return "not found";
        }
