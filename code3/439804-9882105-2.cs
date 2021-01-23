    foreach(Code c in listCodes) {
       Thread tr = new Thread(delegate() {
           if(Monitor.TryEnter(c)) {
               Execute(c.CodeLine);
               Monitor.Exit(c);
           }
       });
    }
