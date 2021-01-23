      int print = 3;
      int skip = 2;
      Boolean isPrintState = true;
      int statePosition = 0;
      StringBuilder Sb = new StringBuilder();
      using (TextReader reader = new StreamReader(@"c:\test.txt")) { 
        while (true) {
          int Ch = reader.Read();
          if (Ch < 0)
            break;
          statePosition += 1;
          if ((isPrintState && (statePosition > print)) || (!isPrintState && (statePosition > skip))) {
            statePosition = 1;
            isPrintState = !isPrintState;
          }
          if (isPrintState) 
            Sb.Append((Char) Ch);
        }
      }
      Console.Write(Sb.ToString());
