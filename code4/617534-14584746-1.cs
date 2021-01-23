    public class Ship
    {
        public void PositionX_pixels_set1(float _position_x){position_x = _position_x;}
    
        private void Engine _myEngine = new Engine(); //DEFINE ENGINE MEMBER
        
        public Engine MyEngine {   //DEFINE A PROPERTY TO ACCESS THAT MEMBER
            get {
               return _myEngine;
            }
        }
    
        public class Engine : Ship
        {
            public int engines() { return 5; }
            private Piston _myPiston = new Piston();//DEFINE PISTON MEMBER
            public class Piston
            {
                public int pistons(){return 5;}
            }
            public Piston MyPiston {return _myPiston;}//DEFINE A PROPERTY TO ACCESS THAT MEMBER
        }
       
    }
