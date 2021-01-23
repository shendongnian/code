    class Locals
    {
        public int i;
        public void M() { Console.Write(this.i);
    }
    ...
    Locals locals = new Locals();
    for (locals.i = 0; locals.i < 10; locals.i++)
      new Thread (locals.M).Start();
