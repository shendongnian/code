    private readonly object obj = new Object();
    
    private readonly List<VacancyTag> _vacancyTags = new List<VacancyTag>();
    
    public virtual void RemoveAllVacancyTags()
    {
        lock(obj)
        {
            _vacancyTags.Clear();
        }
    }
