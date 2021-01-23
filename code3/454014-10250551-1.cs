     SomeDelegate x = SomeMethod;
     SomeDelegate y = SomeOtherMethod;
     var iar1 = x.BeginInvoke(null, null);
     var iar2 = y.BeginInvoke(null, null);
     // Program would still be executing here...
     x.EndInvoke(iar1);
     y.EndInvoke(iar2);
     // Quit
