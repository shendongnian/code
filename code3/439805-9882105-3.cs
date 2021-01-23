    foreach(Code c in listCodes) {
       Code a = c;
       new Thread(delegate() {
           if(Monitor.TryEnter(a)) {
               Execute(a.CodeLine);
               Monitor.Exit(a);
           }
       }) { IsBackground = true }.Start();
    }
