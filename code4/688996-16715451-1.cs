    public class MyVSPackage
    { 
       TextEditorEvents _textEditorEvents;
       public MyVSPackage()
       {
            _textEditorEvents = DTE.Events.TextEditorEvents;
            _textEditorEvents.LineChanged += (point, endPoint, hint) => //Do something here
       }
    }
