    public static void LiberarLista<T>(this List<T> lista)
    {
         lista.Clear();            
         int identificador = GC.GetGeneration(lista);
         GC.Collect(identificador, GCCollectionMode.Forced);
    }
