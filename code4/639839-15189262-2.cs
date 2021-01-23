    public static dynamic Sum( params dynamic[] args ) {
        dynamic sum = 0;
        
        foreach( var arg in args ){
            sum += arg;
        }
        return sum;
    }
