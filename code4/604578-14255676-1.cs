    void MyLoop(int start, int finish, string op)
    {
        if ((op.Equals("++") && (start < finish))
        {
          for(var i = start; i < finish; i++)
          {
              //processMethod(i)
          }
        }
        else if ((op.Equals("--") && (start > finish))
        {
          for(var i = start; i < finish; i--)
          {
              //processMethod(i)
          }
        }
    }
