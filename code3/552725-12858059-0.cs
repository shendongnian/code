    public static long MagnitudeEstimate(BigInteger value)
    {
          var fieldInfo = typeof(BigInteger).GetField("_bits", BindingFlags.Instance | BindingFlags.NonPublic);
          var arr = (uint[])fieldInfo.GetValue(value);
          if (arr != null)
          {
                int totalNumBytes = arr.Length * sizeof(uint);
                int zeroBytes = 0;
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                      if (arr[i] == 0)
                      {
                            zeroBytes += 4;
                            continue;
                      }
                      else if (arr[i] <= 0xFF)
                            zeroBytes += 3;
                      else if (arr[i] <= 0xFFFF)
                            zeroBytes += 2;
                      else if (arr[i] <= 0xFFFFFF)
                            zeroBytes += 1;
    
                      break;
                }
    
                return (long)((totalNumBytes - zeroBytes) * 2.408239965);
          }
          else return 0;
    }
