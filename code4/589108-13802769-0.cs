    class Argument : BaseArgument    {    }
    class BaseArgument    {    }
    class BaseResult    {    }
    class Result : BaseResult    {    }
    delegate BaseResult MyDelegate(Argument argument);
    class Test
    {
        public Test()
        {
         var d1 = new MyDelegate(Method1);
        }
        Result Method1(BaseArgument a)
        {
            return null;
        }
    }
