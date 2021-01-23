4. Insert the desired tooltip logic in RenderLabel:if (itemField.Description.Length > 0)
{
      str4 = " title=\"" + itemField.Description + " (custom text)\"";
}
5. Create a pipeline processor to replace Sitecore's EditorFormatter with yours:using Sitecore.Shell.Applications.ContentEditor.Pipelines.RenderContentEditor;
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
