    using Rhino.Commands;
    [CommandStyle(ScriptRunner)]
    class MyCommand : Rhino.Commands.Command
    {
      public override string EnglishName { get { return "MyCommand"; } }
      protected override Result RunCommand(RhinoDoc doc, RunMode mode)
      {
        RhinoApp.RunScript(@"-_Open C:\model.3dm");
      }
    }
