    class MaleChild : Parent
    {
        public new void foo()
        {
            base.foo();
            Console.WriteLine("Hello from the foo inside MaleChild");
        }
        public override void bar()
        {
            base.bar();
            Console.WriteLine("Hello from the bar inside MaleChild.");
        }
    }
