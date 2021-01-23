        static bool IsJaggedArray(object obj) {
            var t = obj.GetType();
            return t.IsArray && t.GetElementType().IsArray;
        }
        static void Test() {
            var a1 = new int[42];
            Debug.Assert(!IsJaggedArray(a1));
            var a2 = new int[4, 2];
            Debug.Assert(!IsJaggedArray(a2));
            var a3 = new int[42][];
            Debug.Assert(IsJaggedArray(a3));
        }
