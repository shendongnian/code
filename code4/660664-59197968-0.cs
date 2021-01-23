foreach ( Type t in new Type[] { typeof( MyType ) } )
{
    List<string> propExample = new List<string>();
    foreach ( var p in t.GetProperties() )
    {
        propExample.Add( p.Name + "=" + HttpUtility.UrlEncode( config.GetHelpPageSampleGenerator().GetSampleObject(p.PropertyType).ToString() ) );
    }
    config.SetSampleForType( string.Join( "&", propExample ), new MediaTypeHeaderValue( "application/x-www-form-urlencoded" ), t );
}
