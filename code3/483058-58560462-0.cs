    public static void ClearMemory<T>(this List<T> lista)
    {
        int identificador = GC.GetGeneration(lista);
        lista.Clear();
        GC.Collect(identificador, GCCollectionMode.Forced);
    }
