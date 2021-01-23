    public static class GroupStore
    {
        private static Lazy<DTO.Group[]> _groups = new Lazy<DTO.Group[]>(GetAll);
        public static DTO.Group[] Groups { get { return _groups.Value; } }
    
        private static DTO.Group[] GetAll()
        {
            var dal = PluginHandler.Instance.GetPlugin();
            return dal.GetAll();
        }
    }
