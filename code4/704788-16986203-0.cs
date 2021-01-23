    using Mono.CSharp;
        public static Type GetFriendlyType(string typeName)
        {
            //this class could use a default ctor with default sensible settings...
            var eval = new Mono.CSharp.Evaluator(new CompilerContext(
                                                     new CompilerSettings(),
                                                     new ConsoleReportPrinter()));
            //MAGIC! 
            object type = eval.Evaluate(string.Format("typeof({0});", typeName));
            return (Type)type;
        }
