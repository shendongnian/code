    public override bool Equals(object obj)
    {
        var marcas = obj as clsMarcas;
        if (marcas != null)
        {
            return IdMarca == marcas.IdMarca;
        }
        return false;
    }
