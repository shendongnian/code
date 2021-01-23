    public interface IFoobar {
       Boolean Foobar(String s);
    }  
    void Main() {
        var foo = new Mock<IFoobar>();
        foo.Setup(x => x.Foobar(It.IsAny<string>()))
           .Returns((string s) => s == "foobar");
        
        foo.Object.Foobar("notbar"); // false
        foo.Object.Foobar("foobar"); // true
    }
    
