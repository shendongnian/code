    public class Foo
    {
        public string text;
    }
    public void Test(Foo bar)
    {
        bar.text = "hello";
        bar = new Foo();
        bar.text = "world";
    }
    var bar = new Foo();
    bar.text= "";
    Test(bar);
    Console.WriteLine(bar.text); // will output "hello"
