    public static decimal GetPrice( 
    		AssetType assetType, 
    		AssetCount assetCount, 
    		decimal unitPrice 
    	) {
    
    		//Handle Exceptional case first
    		if( assetType == AssetType.Property ) {
    			if (assetCount == AssetCount.One){
    				return 0;
    			}
    		}
    		switch( assetCount ) {
    			case AssetCount.None:
    				return 0;
    			case AssetCount.One:
    				return ( unitPrice );
    			case AssetCount.Two:
    				return ( unitPrice * 2 );
    			case AssetCount.ThreeOrMore:
    				return ( unitPrice * 3);
    				
    		}
    		throw new Exception( "Unsupported AssetCount" );
    }
