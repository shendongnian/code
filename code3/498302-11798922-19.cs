    public abstract class TemplateBaseExtensions<T> : TemplateBase<T>
    {
        public string RenderPart(string templateName, object model = null)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Templates", templateName);
            return Razor.Parse(File.ReadAllText(path), model);
        }
    }
