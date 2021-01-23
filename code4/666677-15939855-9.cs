    public class Foo
    {
        public string text;
    }
    public void Test(Foo bar)
    {
        bar.text = "hello";
        bar = new Foo(); //assigned to variable: it now referrs to a different object. original remains unchanged
        bar.text = "world";
    }
    var bar = new Foo();
    bar.text= "";
    Test(bar);
    Console.WriteLine(bar.text); // will output "hello"
