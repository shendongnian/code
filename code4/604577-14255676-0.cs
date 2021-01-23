    void MyLoop(int start, int finish, string op)
    {
        if (op.Equals("++"))
        {
          for(var i = start; i < finish; i++)
          {
              //do stuff with i
          }
        }
        else if (op.Equals("--"))
        {
          for(var i = start; i < finish; i--)
          {
              //do stuff with i
          }
        }
    }
