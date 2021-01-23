    class Node<T> where T : ISomeInterface {
        T obj;
        public Node(T inject) {
            obj = inject;
        }
    }
