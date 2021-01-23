    double vdouble = 0;
    string sparam = "2,1";
    if ( !Double.TryParse( sparam, NumberStyles.Float, CultureInfo.InvariantCulture, out vdouble ) )
    {
        if ( sparam.IndexOf( '.' ) != -1 )
        {
            sparam = sparam.Replace( '.', ',' );
        }
        else
        {
            sparam = sparam.Replace( ',', '.' );
        }
        if ( !Double.TryParse( sparam, NumberStyles.Float, CultureInfo.InvariantCulture, out vdouble ) )
        {
            vdouble = 0;
        }
    }
