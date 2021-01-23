    class GetDescriptionAttributes<T> : AbstractAttributes<T, DescriptionAttribute>
    {
        public List<string> Descriptions { get; set; }
        public GetDescriptionAttributes()
        {
            Descriptions = Attributes.Select(x => x.Description).ToList();
        }
    }
