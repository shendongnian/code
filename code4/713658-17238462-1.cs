    class B
    {
        int count<T>(T obj) where T : A
        {
            // Here you can:
            // 1. Use obj as you would use any instance or derived instance of A.
            // 2. Pass T as a type param to other generic methods, 
            //    such as conn.table<T>(...)
        }
    }
