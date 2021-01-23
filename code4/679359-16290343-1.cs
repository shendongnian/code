    class foo{
       int H {get;set;}
       int K {get;set;}
       public override bool Equals(object obj){
             if(obj == null) return false;
             foo test = (foo)obj)
             if(test == null) return false;
             
             if(this.H == obj.H && this.K == obj.K) return true;
       }
       public override int GetHashCode(){
             int hashH = H.GetHashCode();
             int hashK = K.GetHashCode();
             return hashH ^ hashK;
       }
       public foo(int _h){
            H = _h;
       }
    }
