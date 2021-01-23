    int a=0,b=0;    
    if(args.Length != 2){
      // not 2 arguments
    }else{
       if(!int.TryParse(args[0], out a) || !int.TryParse(args[1], out b)){
          // not numbers
       }else{
          if(a < 1 || a > 100 || b < 1 || b > 750){
             // out of ranges
          }else{
             // everything fine
          }
       }
    }
