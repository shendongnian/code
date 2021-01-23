    // The original type, unmodified
    class Pair<T> {
        public T First, Second;
    }
    // Interface for any Action on a Pair<T>
    interface IPairVisitor {
        void Visit<T>(Pair<T> pair);
    }
    class PairSwapVisitor : IPairVisitor {
        public void Visit<T>(Pair<T> pair) {
            Application.Swap(pair);
        }
    }
    class PairPrintVisitor : IPairVisitor {
        public void Visit<T>(Pair<T> pair) {
            Console.WriteLine("Pair<{0}>: ({1},{2})", typeof(T), pair.First, pair.Second);
        }
    }
    // General interface for a container that follows the Visitor pattern
    interface IVisitableContainer<T> {
        void Accept(T visitor);
    }
    // The implementation of our Pair-Container
    class VisitablePairList : IVisitableContainer<IPairVisitor> {
        private List<Action<IPairVisitor>> m_visitables = new List<Action<IPairVisitor>>();
        public void Add<T>(Pair<T> pair) {
            m_visitables.Add(visitor => visitor.Visit(pair));
        }
        public void Accept(IPairVisitor visitor) {
            foreach (Action<IPairVisitor> visitable in m_visitables)
                visitable(visitor);
        }
    }
    static class Application {
        public static void Swap<T>(Pair<T> pair) {
            T temp = pair.First;
            pair.First = pair.Second;
            pair.Second = temp;
        }
        static void Main() {
            VisitablePairList list = new VisitablePairList();
            list.Add(new Pair<int> { First = 1, Second = 2 });
            list.Add(new Pair<string> { First = "first", Second = "second" });
            list.Accept(new PairSwapVisitor());
            list.Accept(new PairPrintVisitor());
            Console.ReadLine();
        }
    }
