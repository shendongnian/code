    public class MailParameters
    {
        public DateTime EndTime { get; private set; }
        public IEnumerable<int> Languages { get; private set; }
        public int Priority { get; private set; }
        public string ProjectName { get; private set; }
        public DateTime StartTime { get; private set; }
        public MailParameters(string projectName, DateTime startTime, DateTime endTime, MailLang language, Priority priority)
            : this(projectName, startTime, endTime, new[] { language }, priority)
        public MailParameters(string projectName, DateTime startTime, DateTime endTime, IEnumerable<MailLang> languages, Priority priority)
        {
            ProjectName = projectName;
            StartTime = startTime;
            EndTime = endTime;
            Languages = languages.Cast<int>();
            Priority = (int)priority;
        }
    }
