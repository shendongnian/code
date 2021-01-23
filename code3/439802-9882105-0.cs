    foreach(Code c in listCodes) {
       Thread tr = new Thread(delegate() {
          try {
              if(Monitor.TryEnter(c)) {
                  Execute(c.CodeLine);
              }
          } finally {
              Monitor.Exit(c);
          }
       });
    }
