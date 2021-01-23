    public MyStaticObject{
        private  Regex r1;
        private  Regex r2;
        
        public Regex R1{
            get{ return r1;}
        }
        //...
        private MyStaticObject instance;
        private MyStaticObject(){
            r1=new Regex(...);
        }
        public MyStaticObject GetInstance(){
            if(instance==null){
                instance= new MyStaticObject();
            }
            return instance;
        }
    }
