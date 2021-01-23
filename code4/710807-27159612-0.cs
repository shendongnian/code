    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Any())
            {
                foreach (var s in args)
                {
                    Console.WriteLine("Checking " + s);
                    DirectoryInfo dir = new DirectoryInfo(s);
                    var files = dir.GetFiles("*.csproj", SearchOption.AllDirectories);
                    var projects = files.Select(x => new Project(x)).ToList();
                    var grouped = projects.GroupBy(x => x.TargetFrameworkVersion);
                    if(grouped.Count()>1)
                    {
                        Console.WriteLine("Solution contains multiple versions of Target Frameworks, this may cause duplicate assemblies in R# cache");
                        foreach (var group in grouped)
                        {
                            Console.WriteLine(group.Key);
                            foreach (var project in group)
                            {
                                Console.WriteLine(project.AssemblyName);
                            }
                        }
                    }
                    //loop through for debugging
                    foreach (var project in projects)
                    {
                        foreach (var reference in project.References)
                        {
                            foreach (var checkProject in projects)
                            {
                                if (checkProject.AssemblyName == reference)
                                {
                                    Console.WriteLine("Reference in" + project.FileName + " referencing " +
                                                      reference+" that should be a ProjectReference, this may cause duplicate entries in R# Cache");
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("Complete");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You must provide a path to scan for csproj files");
            }
        }
        
    }
    public class Project
    {
        public string FileName { get; set; }
        public string AssemblyName { get; set; }
        public string ProjectGuid { get; set; }
        public string TargetFrameworkVersion { get; set; }
        public IList<string> References { get; set; }
        private FileInfo _file;
        private XmlDocument _document;
        private XmlNamespaceManager _namespaceManager;
        public Project(FileInfo file)
        {
            _file = file;
            FileName = _file.FullName;
            _document = new XmlDocument();
            _document.Load(_file.FullName);
            _namespaceManager = new XmlNamespaceManager(_document.NameTable);
            _namespaceManager.AddNamespace("msbld", "http://schemas.microsoft.com/developer/msbuild/2003");
            var projectGuidNode = _document.SelectSingleNode("//msbld:ProjectGuid", _namespaceManager);
            ProjectGuid = projectGuidNode.InnerText;
            var assemblyNameNode = _document.SelectSingleNode("//msbld:AssemblyName", _namespaceManager);
            AssemblyName = assemblyNameNode.InnerText;
            var targetFrameworkNode = _document.SelectSingleNode("//msbld:TargetFrameworkVersion", _namespaceManager);
            TargetFrameworkVersion = targetFrameworkNode.InnerText;
            References = new List<string>();
            var referenceNodes = _document.SelectNodes("//msbld:Reference", _namespaceManager);
            foreach (var node in referenceNodes)
            {
                var element = (XmlElement) node;
                //file references
                if (element.HasChildNodes)
                {
                    foreach (var child in element.ChildNodes)
                    {
                        var childElement = (XmlElement)child;
                        if (childElement.Name == "HintPath")
                        {
                            var value = childElement.InnerText;
                            value = value.Substring(value.LastIndexOf("\\") + 1);
                            value = value.Replace(".dll", "");
                            References.Add(value);
                        }
                    }
                }
                //gac references
                else
                {
                    foreach (var attr in element.Attributes)
                    {
                        var attribute = (XmlAttribute)attr;
                        if (attribute.Name == "Include")
                        {
                            var value = attribute.Value;
                            string reference = value;
                            if (value.Contains(','))
                            {
                                reference = value.Substring(0, value.IndexOf(','));
                            }
                            References.Add(reference);
                            break;
                        }
                    }
                }
                
                
            }
        }
    }
