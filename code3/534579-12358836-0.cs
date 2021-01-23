    public class Component
    {
        public Component Parent { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public List<Component> Components { get; set; }
        public Component FindByName(string searchTerm)
        {
            if (searchTerm == Name)
                return this;
            var result = null;
            foreach (var c in Components)
            {
                var result = c.FindByName(searchTerm);
                if (result != null) 
                    break;
            }
            return result;
        }
        public string FullPath
        {
            get { return this.GetFullPath(); }   
        }
        private string GetFullPath()
        {
            var fullPath = Path;
            var parent = Parent;
            while (parent != null)
            {
                fullPath = String.Format("{0}{1}{2}", parent.FullPath, System.IO.Path.DirectorySeparatorChar, fullPath)
            }
            return path;
        }
    }
