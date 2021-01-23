    using Bt = Trees.BinaryTree;       // Has Tree type.
    using Rbt = Trees.RedBlackTree;    // Annoyingly, also has Tree type.
    Tree t = new Tree();               // Is this binary or redbalck?
    Bt.Tree t1 = new Bt.Tree();        // Definite type.
    Rbt.Tree t2 = new Rbt.Tree();      // Ditto.
