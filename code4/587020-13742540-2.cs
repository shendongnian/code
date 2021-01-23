    public bool IsOk(string value){
       if(value.length != 3) return false;
       switch(value[0]){
           case 'P':
           case 'T':
           case 'Q':
           case 'A':
              switch(value[1]){
                   case '0':
                   case '8':
                       switch(value[2]){
                            case '0':
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                            case '5':
                            case '6':
                            case '7':
                                return true;
                       }
             }
    
       }
       return false;
    }
