    public bool IsSubsetof(int[] opciones, IEnumerable<Etiquetas> tags)
    { 
        int[] tagens;
        tagens= new int[tags.Count()];
        for (int i = 0; i < tagens.Length; i++)
        {
            tagens[i] = tags.ToArray()[i].EtiquetaId;
        }
        return !opciones.Except(tagens).Any();
    }
