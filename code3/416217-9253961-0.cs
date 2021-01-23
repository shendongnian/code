    public override string OuterXml {
      get {
        this.AppendChild( this.Location );
        this.AppendChild( this.Size );
        this.AppendChild( this.Hotspot );
        foreach( RGB shad in this.Shading ) {
          this.AppendChild( shad );
        }
        foreach( RGB spec in this.Specular ) {
          this.AppendChild( spec );
        }
        return base.OuterXml;
      }
