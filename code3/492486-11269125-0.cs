        private List<Page> _pages  = null;
        public override List<Page> Pages
        {
              get 
              {  
                    if(pages == null) 
                    {
                      _pages = new List<Page>();
                      _pages .Add(new SkillsPage());
                      _pages .Add(new EducationPage());
                      _pages .Add(new ExperiencePage());
                    }
    
                    return _pages; 
               }
             
            }
        }
