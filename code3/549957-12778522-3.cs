    public class ProjectFeature
    {
        public readonly string Project;
        public readonly string Feature;
        public ProjectFeature(string project, string feature)
        {
            this.Project = project;
            this.Feature = feature;
        }
        public static IEnumerable<ProjectFeature> ParseList(IEnumerable<string> input)
        {
            return input.Select(v =>
            {
                var split = v.Split('@');
                return new ProjectFeature(split[1], split[0]);
            }
        }
    }
