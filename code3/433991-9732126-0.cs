    class ProxyTerm : ITerm {
    
         ITerm Reference { get; set; }
         ITerm.SomeMethod() {
              Reference.SomeMethod();
         }
     
    }
