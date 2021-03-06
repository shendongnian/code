    public class OverflowlessStack <T>
    {
        internal sealed class SinglyLinkedNode
        {
            //Larger the better, but we want to be low enough
            //to demonstrate the case where we overflow a node
            //and hence create another.
            private const int ArraySize = 2048;
            T [] _array;
            int _size;
            public SinglyLinkedNode Next;
            public SinglyLinkedNode()
            {
                _array = new T[ArraySize];
            }
            public bool IsEmpty{ get{return _size == 0;} }
            public SinglyLinkedNode Push(T item)
            {
                if(_size == ArraySize - 1)
                {
                    SinglyLinkedNode n = new SinglyLinkedNode();
                    n.Next = this;
                    n.Push(item);
                    return n;
                }
                _array [_size++] = item;
                return this;
            }
            public T Pop()
            {
                return _array[--_size];
            }
        }
        private SinglyLinkedNode _head = new SinglyLinkedNode();
    
        public T Pop ()
        {
            T ret = _head.Pop();
            if(_head.IsEmpty && _head.Next != null)
                _head = _head.Next;
            return ret;
        }
        public void Push (T item)
        {
            _head = _head.Push(item);
        }
        public bool IsEmpty
        {
            get { return _head.Next == null && _head.IsEmpty; }
        }
    }
    public static BigInteger Ackermann(BigInteger m, BigInteger n)
    {
        var stack = new OverflowlessStack<BigInteger>();
        stack.Push(m);
        while(!stack.IsEmpty)
        {
            m = stack.Pop();
        skipStack:
            if(m == 0)
                n = n + 1;
            else if(m == 1)
                n = n + 2;
            else if(m == 2)
                n = n * 2 + 3;
            else if(n == 0)
            {
                --m;
                n = 1;
                goto skipStack;
            }
            else
            {
                stack.Push(m - 1);
                --n;
                goto skipStack;
            }
        }
        return n;
    }
