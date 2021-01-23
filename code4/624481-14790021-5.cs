4. Insert the desired tooltip logic in RenderLabel:if (itemField.Description.Length > 0)
{
      str4 = " title=\"" + itemField.Description + " (custom text)\"";
}</pre> **Note:** You can replace **(custom text)** with your new logic.  Also note that you may wish to remove the check on the Description.Length, as this will prevent your new tooltip from appearing if the Description is not populated.
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
</pre>  Populating EditorFormatter.Arguments is necessary to prevent a null object exception.  
