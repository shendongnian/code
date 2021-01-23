    public static void Dispose<T>(this List<T> list) where T : IDisposable {
        for (int i = 0, il = list.Count; i < il; i++) {
            list[i].Dispose();
        }
        list.Clear();
    }
