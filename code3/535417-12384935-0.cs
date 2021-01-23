    class AVL_tree
    {
        public Node root;
        // ...
        public void Write(int value)
        {
            root = new Node();         // [A]
            root.ww.EnterWriteLock();  // [B]
            if (!root.ww.IsWriteLockHeld) throw new Exception("Why?"); // [C]
            // ...
            root.ww.ExitWriteLock();
        }
    }
