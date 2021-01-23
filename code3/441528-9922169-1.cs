        public virtual void Method1()
        {
          Console.WriteLine("Method1 in Base class.");
          this.Method2Private( );
        }
    
        private void Method2Private()
        {
          Console.WriteLine( "Method2 in Base class." );
        }
        public virtual void Method2()
        {
          Method2Private();
        }
