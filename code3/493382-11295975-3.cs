         private static unsafe double InternalRound(double value, int digits, MidpointRounding mode) {
                if (Abs(value) < doubleRoundLimit) {
                    Double power10 = roundPower10Double[digits];
                    value *= power10;
                    if (mode == MidpointRounding.AwayFromZero) {                
                        double fraction = SplitFractionDouble(&value); 
                        if (Abs(fraction) >= 0.5d) {
                            value += Sign(fraction);
                        }
                    }
                    else {
                        // On X86 this can be inlined to just a few instructions
                        value = Round(value);
                    }
                    value /= power10;
                }
                return value;
              }           
    
    
         public static double Round(double value, int digits)
          {
               if ((digits < 0) || (digits > maxRoundingDigits))
                   throw new ArgumentOutOfRangeException("digits", Environment.GetResourceString("ArgumentOutOfRange_RoundingDigits"));
               return InternalRound(value, digits, MidpointRounding.ToEven);                     
          }
    
      public static double Round(double value, MidpointRounding mode) {
             return Round(value, 0, mode);
          }
          
          public static double Round(double value, int digits, MidpointRounding mode) {
              if ((digits < 0) || (digits > maxRoundingDigits))
                  throw new ArgumentOutOfRangeException("digits", Environment.GetResourceString("ArgumentOutOfRange_RoundingDigits"));
              if (mode < MidpointRounding.ToEven || mode > MidpointRounding.AwayFromZero) {            
                  throw new ArgumentException(Environment.GetResourceString("Argument_InvalidEnumValue", mode, "MidpointRounding"), "mode");
              }
              return InternalRound(value, digits, mode);                           
          }
                                                    
          public static Decimal Round(Decimal d) {
            return Decimal.Round(d,0);
          }
    
          public static Decimal Round(Decimal d, int decimals) {
            return Decimal.Round(d,decimals);
          }
          
          public static Decimal Round(Decimal d, MidpointRounding mode) {
            return Decimal.Round(d, 0, mode);
          }
          
          public static Decimal Round(Decimal d, int decimals, MidpointRounding mode) {
            return Decimal.Round(d, decimals, mode);
          }
