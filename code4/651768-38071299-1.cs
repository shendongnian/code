    Feature: Feateure1
    
    Scenario: demo
    Given I am at the Home Page
    When ....
    
    [Binding, Scope(Feature = "Feateure1")]
    public class Steps1{
    
     [Given(@"Given I am at the Home Page")]
     public void GivenIAmAtTheHomePage(){
      {  }
    }
    
    Feature: Feateure2
    
    Scenario: demo
    Given I am at the Home Page
    When ....
    ...
    
    [Binding,Scope(Feature = "Feateure2")]
    public class Steps2{
    
     [Given(@"Given I am at the Home Page")]
     public void GivenIAmAtTheHomePage(){
     {  }
    
    }
