    abstract class Document{
        public IEnumerable<Page> Pages{
            get { return CreatePages();}
        }
    
        // Factory Method
        protected abstract IEnumerable<Page> CreatePages();
    }
    
    class Resume : Document{
        // Factory Method implementation
        protected override IEnumerable<Page> CreatePages(){
             List<Page> _pages = new List<Page>();
            _pages .Add(new SkillsPage());
            _pages .Add(new EducationPage());
            _pages .Add(new ExperiencePage());
            return _pages;
           }
        }
    }
