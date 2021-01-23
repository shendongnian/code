    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    
    namespace Test
    {
        class Program
        {
            public static object CompareVal(Foo logic)
            {
                switch(logic.ValueType)
                {
                    case ValueTypes.Integer: return Convert.ToInt32(logic.Value);
                    case ValueTypes.Long:    return Convert.ToInt64(logic.Value);
                    case ValueTypes.Numeric: return Convert.ToDecimal(logic.Value);
                    case ValueTypes.Date:    return Convert.ToDateTime(logic.Value);
                    case ValueTypes.Text:    return logic.Value;
                    case ValueTypes.Bool:    return Convert.ToBoolean(logic.Value);
                }
                throw new InvalidProgramException("Unsupported ValueType");
            }
    
            public static bool Evaluate(dynamic val, Foo logic)
            {
                object cmpval = CompareVal(logic);
    
                switch(logic.OperatorType)
                {
                    case OperatorTypes.Equal:          return val == cmpval;
                    case OperatorTypes.Greater:        return val >  cmpval;
                    case OperatorTypes.GreaterOrEqual: return val >= cmpval;
                    case OperatorTypes.Less:           return val <  cmpval;
                    case OperatorTypes.LessOrEqual:    return val <= cmpval;
                }
    
                return false;
            }
    
            static void Main(string[] args)
            {
                //compare compare1 and foo1.Value, output should be false (2 < 3)
                Debug.Assert(false == Evaluate(3, new Foo 
                            { 
                                Value = "2", 
                                OperatorType = OperatorTypes.GreaterOrEqual, 
                                ValueType = ValueTypes.Long 
                            }));
    
                //compare compare2 and foo2.Value, output should be true (true = true)
                Debug.Assert(true == Evaluate(true, new Foo 
                            { 
                                Value = "True", 
                                OperatorType = OperatorTypes.Equal, 
                                ValueType = ValueTypes.Bool 
                            }));
    
                //compare compare3 and foo3.Value, output should be false (2013-03-19 16:00 < 2013-03-19 15:00)
                Debug.Assert(false == Evaluate(DateTime.Parse("2013-03-19 15:00"), new Foo 
                            { 
                                Value = "2013-03-19 16:00", 
                                OperatorType = OperatorTypes.Less, 
                                ValueType = ValueTypes.Date 
                            }));
            }
        }
    
        public enum OperatorTypes : uint
        {
            Equal = 1,
            Greater = 2,
            GreaterOrEqual = 3,
            Less = 4,
            LessOrEqual = 5
        }
    
        public enum ValueTypes : uint
        {
            None = 0,
            Integer = 1,
            Long = 2,
            Numeric = 3,
            Date = 4,
            Text = 5,
            Bool = 6
        }
    
        class Foo
        {
            public string Value { get; set; }
            public ValueTypes ValueType { get; set; }
            public OperatorTypes OperatorType { get; set; }
        }
    }
