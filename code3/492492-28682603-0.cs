    public class Document
        private readonly PageList as IList(of IPage)
        
        public readonly property Pages as IEnumerable(of IPage)
            get
                return PageList
            end get
        end property
        public sub new()
            Me.PageList = new List(of IPage)
        end sub
        protected sub Add(paramarray Pages() as IPage)
            Me.Pages.AddRange(Pages)
        end sub
    end public
    public class Resume
        inherits Document
        public sub new()
            mybase.add(new SkillsPage, new EducationPage, new ExperiencePage)
        end sub
    end class
