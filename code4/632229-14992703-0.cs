    /// <summary>
    /// Converts this shape into a Geometry using the default factory.
    /// </summary>
    /// <returns>The geometry version of this shape.</returns>
    public IGeometry ToGeometry()
    {
        return ToGeometry(Geometry.DefaultFactory);
    }
