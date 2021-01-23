    public static void SetMethod(this ScriptScope scope, string name, Delegate method)
    {
        scope.SetVariable(name + "__delegate", method);
        scope.Engine.Execute("def " + name + "(*args, &block)\nargs.push block if block != nil\n" + name + "__delegate.invoke(*args)\nend", scope);
    }
