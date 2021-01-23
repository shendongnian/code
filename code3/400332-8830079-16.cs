    class Visitor : IVisitor
    {
        public void Visit(Gamma gamma) { Console.WriteLine("Visiting Gamma object"); }
        public void Visit(Epsilon epsilon) { Console.WriteLine("Visiting Epsilon object"); }
        public void Visit(Beta beta) { Console.WriteLine("Visiting Beta object"); }
        public void Visit(Alpha alpha) { Console.WriteLine("Visiting Alpha object"); }
    }
