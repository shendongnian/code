    for (int i = 0; i < Memory.Count; i++ )
    {
        var piezas = Memory.FindAll(s => (s.Name != Memory[i].Name 
              && Utilidades.CompareImage(s.Image, Memory[i].Image)));
        if (piezas.Count > 0)
        {
            // use piezas[0] somehow
            break;
        }
    }
