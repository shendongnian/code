    for (int i = 0; i < Memory.Count; i++ )
    {
        var piezas = Memory.FindAll(s => (s.Name != Memory[i].Name 
              && Utilidades.CompareImage(s.Image, Memory[i].Image)));
    }
