    using System;
    using System.Diagnostics ;
    
    StackTrace st=new StackTrace (0,true);
    
    StackFrame sf=new StackFrame ();
    sf=st.GetFrame (0);
    Console.WriteLine ("FileName: {0}",sf.GetFileName ());
    Console.WriteLine ("Line Number: {0}",sf.GetFileLineNumber ());
    Console.WriteLine ("Function Name: {0}",sf.GetMethod ());
    
