    public class FormStack 
        : IEnumerable<Form> //implement IEnumerable<Form> or just SelectMany
    {    
        public Form Form { get; set; }
        public FormStack Parent { get; set; }        
    }
