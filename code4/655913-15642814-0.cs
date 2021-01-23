		static Stream responseStream( this HttpWebResponse resp )
		{
			if( null == resp ) return null;
			string enc = resp.Headers[ HttpRequestHeader.ContentEncoding ];
			if( !string.IsNullOrEmpty( enc ) )
			{
				enc = enc.ToLower();
				if( enc == "gzip" )
					return new GZipInputStream( resp.GetResponseStream() );
			}
			return resp.GetResponseStream();
		}
