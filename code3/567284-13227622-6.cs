    public class FormStack : IEnumerable<Form> // or just implement SelectMany
    {    
        public Form Form { get; set; }
        public FormStack Parent { get; set; }  
        //implement IEnumerable<Form> or the SelectMany method
    }
