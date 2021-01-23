    public class B(string id, int size) : base(id, size)
      {
        this.Name = "Name2";
        this.Something = new SomethingElse(id, size);
      }
