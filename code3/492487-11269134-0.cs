    public abstract class Document {
        protected Document(IEnumerable<Page> pages) {
            // If it's OK to add to _pages, do not use AsReadOnly
            _pages = pages.ToList().AsReadOnly();
        }
        // ...
    }
    public class Resume : Document {
        public Resume() : base(CreatePages()) {
        }
        private static IEnumerable<Page> CreatePages() {
            return new Page[] {
                new SkillsPage(),
                new EducationPage(),
                new ExperiencePage()
            };
        }
    }
