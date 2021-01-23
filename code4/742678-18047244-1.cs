                    else if (number >= 10 && number < 100)
                  {
                  if(number > 10)
                  {
                      if (number > 10 && number < 20)
                      {
                          for (int x = 11; x < 20; x++)
                          {
                              if (number == x)
                              {
                                  ConvertedNumber += teens[x - 11];
                                  
                              }
                          }
                          ***number -= 100;***
                      }
                      else
                      {
                          number -= 10;
                          Count++;
                          ConvertedNumber += tens[Count - 1];
                      }
                      
                  }
              }
