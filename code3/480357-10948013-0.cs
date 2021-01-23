    private abstract class Logic
    {
        protected double FVAL(object arg)
        {
            // put code here
            return 0;
        }
        protected double ORGVAL(object arg)
        {
            // put code here
            return 0;
        }
        protected double ORGVAL(object arg, string date)
        {
            // put code here
            return 0;
        }
        public abstract double GetValue(object PFC, object BAS, object DA);
    }
    private class DynamicLogic : Logic
    {
        public override double GetValue(object PFC, object BAS, object DA)
        {
            return (FVAL(PFC) = true ? ((ORGVAL(BAS, "2012/12/31") + ORGVAL(DA)) < 6500 ? (FVAL(BAS) + FVAL(DA)) * .12 : 780) : 0);
        }
    }
    private Logic GenerateLogic(string code)
    {
        using (CSharpCodeProvider provider = new CSharpCodeProvider())
        {
            StringBuilder classCode = new StringBuilder();
            classCode.AppendLine("private class DynamicLogic : Logic");
            classCode.AppendLine("    {");
            classCode.AppendLine("        public override int GetValue(object PFC, object BAS, object DA)");
            classCode.AppendLine("        {");
            classCode.AppendLine("            return (" + code + ");");
            classCode.AppendLine("        }");
            classCode.AppendLine("    }");
            CompilerParameters p = new CompilerParameters();
            p.GenerateInMemory = true;
            p.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CompilerResults results = provider.CompileAssemblyFromSource(p, code);
            return (Logic)Activator.CreateInstance(type);
            if (results.Errors.HasErrors)
            {
                throw new Exception("Failed to compile DynamicLogic class");
            }
            return (Logic)results.CompiledAssembly.CreateInstance("DynamicLogic");
        }
    }
    private double evaluate(object PFC, object BAS, object DA)
    {
        Logic logic = GenerateLogic("FVAL(PFC) = true ? ((ORGVAL(BAS, \"2012/12/31\") + ORGVAL(DA)) < 6500 ? (FVAL(BAS) + FVAL(DA)) * .12  : 780) : 0");
        return logic.GetValue(PFC, BAS, DA);
    }
