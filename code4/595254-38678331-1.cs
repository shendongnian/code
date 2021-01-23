    public class ExecFunctionService : IExecFunction
    {
        // this is a GET  /fubar/1,2,3,4
        public Result CalcThis(string function, string args)
        {
            // function=fubar
            // args = 1,2,3,4
            var allargs = args.Split(',');
    
            // store each argument with their type
            var typeList = new List<Tuple<Type, object>>();
            // parsr to gind the best match
            foreach(var arg in allargs)
            {
                // convert each argument string
                // to a type that is supported
                int i;
                if (Int32.TryParse(arg, out i))
                {
                    typeList.Add(new Tuple<Type,object>(typeof(Int32), i));
                    continue;
                }
                double d;
                if (Double.TryParse(arg, 
                       NumberStyles.AllowDecimalPoint,
                       new CultureInfo("en-us"), 
                       out d))
                {
                    typeList.Add(new Tuple<Type,object>(typeof(Double), d));
                    continue;
                }
                // if all fails assume string
                typeList.Add(new Tuple<Type,object>(typeof(string), arg));
            }
    
            // find and call the correct method
            // notice that parameters and their type do matter
            // overloads of the same methodname with 
            // different types is supported
            // Functions is the static type with methods to call
            var method = typeof(Functions).GetMethod(
                function,
                BindingFlags.Static| BindingFlags.Public |BindingFlags.InvokeMethod,
                null, 
                typeList.Select(ty => ty.Item1).ToArray(), //all types
                null);
            var callresult = method.Invoke(
                null, 
                typeList.Select(ty => ty.Item2).ToArray()); // all values
    
            // shape the output in the form you need
            var result = new Result();
            if(callresult is double)
            {
                result.DoubleResult = (double) callresult;
            }
            if (callresult is int)
            {
                result.IntResult = (int)callresult;
            }
            if (callresult is string)
            {
                result.Message = (string)callresult;
            }
    
            return result;
        }
    }
