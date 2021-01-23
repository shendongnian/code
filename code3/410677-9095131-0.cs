    public class IronPythonConsoleHost : ConsoleHost
    {
        // Full version
        public IronPythonConsoleHost(
           Func<ScriptEngine, CommandLine, ConsoleOptions, IConsole> consoleSelector)
        {
            _consoleSelector = consoleSelector;
        }
        public IronPythonConsoleHost(Func<IConsole> consoleSelector)
            this((engine, commandLine, options) => consoleSelector())
        {
        }
        ...
        public override IConsole CreateConsole(ScriptEngine engine,
            CommandLine commandLine, ConsoleOptions options)
        {
            return _consoleSelector(engine, commandLine, options);
        }
        ...
    }
