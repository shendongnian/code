    void MyMethod( params object[] arr ) {
        var d = new Dictionary<string,object>();
        for( int i=0; i<arr.Length; i+=2 ) {
            d.Add( (string)arr[i], arr[i+1] );
        }
    }
