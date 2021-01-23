public class Person
{
  public string Name {get; set;}
  public string FirstName {get; set;}
  ...
}
With your approach you are breaking this idea, because you're passing the DataReader to presenetation layer which implies, that you cannot switch the DAL technology without touching the other layers. E.g. if you want to use Entity Framework you would have to modify every part in the code, where you're currently using the SqlDataReader.
