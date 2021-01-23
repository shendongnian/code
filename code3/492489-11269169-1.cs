    abstract class Document{
        protected List<Page> _pages = new List<Page>();
    
        // Constructor calls abstract Factory method
        public Document(){}
    
        public List<Page> Pages
        {
            get { CreatePages(); return _pages; }
        }
    
        // Factory Method
        protected abstract void CreatePages();
    }
    
    class Resume : Document{
        // Factory Method implementation
        protected override void CreatePages(){
           if(pages.Count == 0 ){
            _pages .Add(new SkillsPage());
            _pages .Add(new EducationPage());
            _pages .Add(new ExperiencePage());
           }
        }
    }
