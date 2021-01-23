    public class TemplateResolver : ITemplateResolver
    {
        public string Resolve(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            string path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Templates", name);
            return File.ReadAllText(path, System.Text.Encoding.Default);
        }
    }
