    class DescriptionAttributes<T> : AbstractAttributes<T, DescriptionAttribute>
    {
        public List<string> Descriptions { get; set; }
        public DescriptionAttributes()
        {
            Descriptions = Attributes.Select(x => x.Description).ToList();
        }
    }
