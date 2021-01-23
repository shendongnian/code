    public ActionResult Index( string file, bool? compress )
    {
    	List< string > requestedFiles;
    	if ( file == "documentation" )
    	{
    		var path = Server.MapPath( "~/Views/Javascript" );
    		requestedFiles = Directory.GetFiles( path, "*.js" ).Select( x => Path.GetFileNameWithoutExtension( x ) ).ToList();
    		return View( file, requestedFiles );
    	}
    
    	requestedFiles = file.Split( ',' ).Select( x => x.Trim() ).ToList();
    
    	var javascript = new StringBuilder();
    	foreach ( var filePath in requestedFiles )
    	{
    		using ( var fs = new FileStream( Path.Combine( Server.MapPath( "~/Views/Javascript" ), filePath + ".js" ), FileMode.Open ) )
    		{
    			var bytes = new byte[fs.Length];
    			fs.Read( bytes, 0, bytes.Length );
    			javascript.AppendLine( Encoding.UTF8.GetString( bytes ).Replace( "~/", FullyQulifiedPathToRoot() ) );
    		}
    	}
    
    	var compressed = javascript.ToString();
    
    	if ( !compress.HasValue || compress == true )
    	{
    		compressed = JavaScriptCompressor.Compress( javascript.ToString(), true, true, true, false, int.MaxValue, Encoding.UTF8, CultureInfo.CurrentCulture, false );
    	}
    
    	return JavaScript( compressed );
    }
    
    private string FullyQulifiedPathToRoot()
    {
    	return System.Web.HttpContext.Current.Request.Url.Scheme + "://" + System.Web.HttpContext.Current.Request.Url.Host + VirtualPathUtility.ToAbsolute( "~/" );
    }
