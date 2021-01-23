    public class TestplanDTO
    {
        public TemplateDTO Template { get; set; }
        public ReleaseDTO Release { get; set; }
        public IEnumerable<TemplateDTO> AvailableTemplates { get; }
        public IEnumerable<ReleaseDTO> AvailableReleases { get; }
    }
