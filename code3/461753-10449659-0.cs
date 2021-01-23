    public class ContentVariablesProcessor
    {
        public void Process(Sitecore.Pipelines.RenderField.RenderFieldArgs args)
        {
            if (args != null)
            {
                // Manipulate output
                args.Result.FirstPart = "my output";
            }
        }
    }
