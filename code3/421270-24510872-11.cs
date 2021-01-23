    // the abstract concept of the system that could be implemented with 
    Selenium, HttpClient, etc. 
    public interface IDocument 
    { 
        string Title { get;} 
        void Load(); 
    } 
    
    // the steps that are executed when the scenarios from your feature 
    file are executed 
    [Binding] 
    public class Steps 
    { 
        private readonly IDocument _document; 
    
        public Steps(IDocument document) 
        { 
            _document = document; 
        } 
    
        [Given("something")] 
        public void GivenSomething() 
        { 
            // set up given state 
        } 
    
        [When("I view the document")] 
        public void WhenIViewTheDocument() 
        { 
            _document.Load(); 
        } 
    
        [Then(@"the title should be ""(.*)""")] 
        public void Then(string title) 
        { 
            Assert.ArEqual(_document.Title, title); 
        } 
    } 
    
    // this is where the magic happens - get the dependency injection 
    // container and register an IDocument implementation
    [Binding] 
    public class Dependencies 
    { 
        private readonly IObjectContainer _objectContainer; 
    
        public Dependencies(IObjectContainer objectContainer) 
        { 
            _objectContainer = objectContainer; 
        } 
    
        [BeforeScenario] 
        public void RegisterDocumentInterfaces() 
        { 
            // register the correct IDocument implementation - UI or API 
        } 
    } 
