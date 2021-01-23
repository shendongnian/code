    using System;
    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;
    class Program
    {
        private static ScriptEngine _python;
        private static readonly string _script = @"
    from System.Windows.Media import Color
    c = Color()
    c.A = 100
    c.B = 200
    c.R = 100
    c.G = 150
    c
    ";
        public static dynamic ExectureStatements(string expression)
        {
            var neededAssembly = typeof(System.Windows.Media.Color).Assembly;
            _python.Runtime.LoadAssembly(neededAssembly);
            ScriptScope scope = _python.CreateScope();
            ScriptSource source = _python.CreateScriptSourceFromString(expression);
            return source.Execute(scope);
        }
        static void Main(string[] args)
        {
            _python = Python.CreateEngine();
            var output = ExectureStatements(_script);
            Console.WriteLine(output);
        }
    }
