    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    
    public class libvlc
    {
        [DllImport("the-vlc.dll", EntryPoint = "Foo")]
        extern public static void Foo( IntPtr bar );
    }
