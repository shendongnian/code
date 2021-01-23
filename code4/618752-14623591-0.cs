    class Component {
        private volatile boolean closed = false;
        public boolean isClosed() { return closed; }
        public void close() { closed = true; }
    }
