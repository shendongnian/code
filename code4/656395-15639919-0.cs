    public override bool Equals( object obj )
    {
        City other = obj as City;
        if ( ( other != null ) && ( other.Id == this.Id ) && ( other.Code == this.Code ) )
        {
            return ( true );
        }
        return ( false );
    }
    public override int GetHashCode( )
    {
        return ( this.Id ^ this.Code.GetHashCode() ) ;
    }
