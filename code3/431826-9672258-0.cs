    abstract class B : A{
      [BsonElement("ln")]
      public string LastName { get; set; }
    }
    class C : B {
      [BsonElement("age")]
      public int Age { get; set; }
    }
