    public class PersonDataTemplateSelector: DataTemplateSelector
    {
    
        public DataTemplate BossTemplate { get; set; }
        public DataTemplate EmployeeTemplate { get; set; }
    
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate selectedTemplate = null;
    
            if (item is Boss)
            {
                selectedTemplate = BossTemplate;
            }
            else
            {
                selectedTemplate = EmployeeTemplate;
            }
    
            return selectedTemplate;
        }
    }
