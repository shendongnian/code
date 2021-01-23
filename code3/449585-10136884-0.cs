     class MyViewModel {
            string ResultStr {
                get {
                    if(a != null && b == null)
                        return "a"; 
                    else if(a == null && b != null)
                        return "b"; 
                }
           }
        }  
