    static class Indent{    
         public static void Run(){
             // implementation
         }
         // other helper methods
    }
    
    static class MacroRunner {
        static MacroRunner() {
            BuildMacroRunnerList();
        }
        static void BuildMacroRunnerList() {
            macroRunners = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.Namespace.ToUpper().Contains("MACRO"))
                .Select(t => (Action)Delegate.CreateDelegate(
                    typeof(Action), 
                    null, 
                    t.GetMethod("Run", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)))
                .ToList();
        }
        static List<Action> macroRunners;
        public static void Run() {
            foreach(var run in macroRunners)
                run();
        }
    }
