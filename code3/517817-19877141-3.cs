    static class PrettyPrinter {
    
        static PrettyPrinter() {
            BuildPrettyPrinterList();
        }
    
        static void BuildPrettyPrinterList() {
            printers = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.Name.EndsWith("PrettyPrinter"))
                .Select(t => (Func<object, string>)Delegate.CreateDelegate(
                    typeof(Func<object, string>), 
                    null, 
                    t.GetMethod("Print", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)))
                .ToList();
        }
    
        static List<Func<object, string>> printers;
    
        public static void Print(object obj) {
            foreach(var printer in printers)
                print(obj);
        }
    }
