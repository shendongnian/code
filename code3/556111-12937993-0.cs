     enum LayerType
    {
        Raster,
        Terrain,
        Vector
    }
    public static ABaseDynamicLayer CreateLayer(LayerType type, int id, string uri)
    {
        ABaseDynamicLayer layer;
        switch (type)
        {
            case LayerType.Raster:
                layer = new RasterDynamicLayer();
                break;
            case LayerType.Terrain:
                layer = new TerrainDynamicLayer();
                break;
            case LayerType.Vector:
                layer = new VectorDynamicLayer();
                break;
        }
        layer.LayerID = id;
        layer.URIPath = uri;
        return layer;
    }
