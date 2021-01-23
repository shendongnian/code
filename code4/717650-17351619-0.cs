    int System.Collections.Generic.IComparer<string>.Compare(string string1, 
                                                     string string2)
    {
      mParser1.Init(string1);
      mParser2.Init(string2);
      int result;
      do
      {
        if (mParser1.TokenType == TokenType.Numerical & 
                     mParser2.TokenType == TokenType.Numerical)
          // both string1 and string2 are numerical 
          result = decimal.Compare(mParser1.NumericalValue, mParser2.NumericalValue);
        else
          result = string.Compare(mParser1.StringValue, mParser2.StringValue);
        if (result != 0) return result;
        else
        {
          mParser1.NextToken();
          mParser2.NextToken();
        }
      } while (!(mParser1.TokenType == TokenType.Nothing & 
                 mParser2.TokenType == TokenType.Nothing));  
      return 0; //identical 
    }
