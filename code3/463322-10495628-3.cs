    interface ISecondDeep
    {
       bool SomethingToDo(string str);
    }
    class SecondDeep : ISecondDeep
    {
        public bool SomethingToDo(string str)
        {
           bool flag = false;
           if (str.Length < 10)
           {
               // without abstraction your test will require database
           }
           return flag;
        }
    }
