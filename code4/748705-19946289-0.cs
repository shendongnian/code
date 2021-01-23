    List<Copyable> list = ...
    for( Copyable obj : list ){
       Copyable copy = obj.clone();
    }
    interface Copyable {
        public Copyable copy();
    }
