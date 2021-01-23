    private IList<Vector3> vertices;
    private IList<uint> indices;
    public Mesh(IList<Vector3> vertices, IList<uint> indices)
    {
        this.vertices = vertices;
        this.indices = indices;
    }
