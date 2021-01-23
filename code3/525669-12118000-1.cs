    class Program
    {
        static void Main( string[] args )
        {
            AppDomain.CurrentDomain.ProcessExit += ProcessExitHandler ;
        }
        static void ProcessExitHandler( object sender , EventArgs e )
        {
            throw new NotImplementedException("You can shut me down. I quit!" ) ;
        }
    }
