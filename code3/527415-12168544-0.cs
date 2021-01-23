    public class MyClass
    {
      private Delegate m_action;
      public object[] m_args;
      
      public MyClass()
      {
      }
      
      public MyClass( Delegate action , params object[] args )
      {
        m_args = args;
        m_action = action;
      }
      
      public void Execute()
      {
        m_action.DynamicInvoke( m_args );
      }
    }
    
    class Program
    {
      static void Main( string[] args )
      {
        Type       tSelf          = typeof(Program) ;
        MethodInfo mi             = tSelf.GetMethod( "FooBar" ) ;
        Delegate   methodDelegate = Delegate.CreateDelegate( typeof(Action<int,int,int>) , mi ) ;
        MyClass    instance      = new MyClass( methodDelegate , 101 , 102 , 103 ) ;
        
        instance.Execute() ;
        
        return;
      }
      
      public static void FooBar( int x , int y , int z )
      {
        Console.WriteLine( "x:{0}, y:{1}, z:{2}" , x , y , z ) ;
        return ;
      }
      
    }
