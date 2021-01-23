    using Sitecore.Shell.Applications.ContentEditor.Pipelines.RenderContentEditor;
    namespace CustomizedEditor
    {
      public class ChangeToMyEditorFormatter : RenderStandardContentEditor
      {
        public void Process(RenderContentEditorArgs args)
        {
            args.EditorFormatter = new MyEditorFormatter();
            args.EditorFormatter.Arguments = args;
        }
      }
    }
