    public double xMax {
          set {
               double val = 0.00f;
               switch(value) {
                    case 0:
                         val = priMax;
                         break;
                    case 1:
                         val = rfMax;
                         break;
                    case 2:
                         val = pwMax;
                         break;
               }
               xmax = value * val; // say // This makes break better in switch.
          }
          get { return xmax; }
     }
