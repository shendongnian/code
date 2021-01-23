public class Person {
  public int Id { get; set; }
  public string Name { get;set; }
  public string Address { get;set; }
}
To:
public class Person {
  public int Id { get; set; }
  public string Name { get;set; }
  public string? Address { get;set; }  //change address to nullable string since it is nullable in database
}
