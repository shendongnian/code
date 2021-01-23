    public  void record()
		{
        // http://relay.pandora.radioabf.net:9000
        String server = "http://radio.mosaiquefm.net:8000/mosalive";
        String serverPath = "/";
        String destPath = "A:\\";			// destination path for saved songs
        String fname="test";
        HttpWebRequest request = null; // web request
        HttpWebResponse response = null; // web response
        int metaInt = 0; // blocksize of mp3 data
        int count = 0; // byte counter
        int metadataLength = 0; // length of metadata header
        byte[] buffer = new byte [ 512 ]; // receive buffer
        Stream socketStream = null;	// input stream on the web request
        Stream byteOut = null; // output stream on the destination file
       
        // create web request
        request = ( HttpWebRequest ) WebRequest . Create ( server );
        // clear old request header and build own header to receive ICY-metadata
        request . Headers . Clear ( );
        request . Headers . Add ( "GET" , serverPath + " HTTP/1.0" );
        request . Headers . Add ( "Icy-MetaData" , "1" ); // needed to receive metadata informations
        request . UserAgent = "WinampMPEG/5.09";
        // execute request
        try
            {
            response = ( HttpWebResponse ) request . GetResponse ( );
            }
        catch ( Exception ex )
            {
            Console . WriteLine ( ex . Message );
            return;
            }
        // read blocksize to find metadata header
        metaInt = Convert . ToInt32 ( response . GetResponseHeader ( "icy-metaint" ) );
        try
            {
            // open stream on response
            socketStream = response . GetResponseStream ( );
            byteOut = createNewFile ( destPath , fname );
            // rip stream in an endless loop
            while ( byteOut . Length <1024000) // 23650000 ~ 30 min     
                {
                // read byteblock
                int bufLen = socketStream . Read ( buffer , 0 , buffer . Length );
                if ( bufLen < 0 )
                    return;
                for ( int i=0 ; i < bufLen ; i++ )
                    {
                      if ( count++ < metaInt ) // write bytes to filestream
                            {
                            if ( byteOut != null ) // as long as we don't have a songtitle, we don't open a new file and don't write any bytes
                                {
                                byteOut . Write ( buffer , i , 1 );
                                if ( count % 100 == 0 )
                                    byteOut . Flush ( );
                                }
                            }
                        else // get headerlength from lengthbyte and multiply by 16 to get correct headerlength
                            {
                            metadataLength = Convert . ToInt32 ( buffer [ i ] ) * 16;
                            count = 0;
                            }
                       }
                    }
                }
            
        catch ( Exception ex )
            {
            Console . WriteLine ( ex . Message );
            }
        finally
            {
            if ( byteOut != null )
                byteOut . Close ( );
            if ( socketStream != null )
                socketStream . Close ( );
            }
        }
