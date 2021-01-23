        interface IPumpable 
        {
            void Pump();
        }
        interface IPoppable
        {
            void Pop();
        }
        class Balloon :IPumpable, IPoppable
        {
            private void IPumpable.Pump()
            {
 	            throw new NotImplementedException();
            }   
            private void IPoppable.Pop()
            {
 	            throw new NotImplementedException();
            }
        }
        public static void PopMethod(IPoppable poppable)
        {
            poppable.Pop();
        }
        public static void PumpMethod(IPumpable pumpable)
        {
            pumpable.Pump();
        }
        static void Main(string[] args)
        {
            Balloon balloon = new Balloon();
            PumpMethod((IPumpable)balloon);
            PopMethod((IPoppable)balloon);
        }
