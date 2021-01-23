    Expression<Func<A,bool>> expr = a => (a.Name == "Alex" && a.DateCreated < DateTime.Now.AddHours(2));
    var expr1 = expr.Body as BinaryExpression;
    var expr2 = expr1.Right as BinaryExpression; //a.DateCreated < DateTime.Now.AddHours(2)
    var expr3 = expr2.Right as MethodCallExpression; //DateTime.Now.AddHours(2)
    var obj = expr3.Object as MemberExpression; //DateTime.Now
    var pi = obj.Member as PropertyInfo;
    var dt = pi.GetValue(null); //Call DateTime.Now
            
    var arg = expr3.Arguments[0] as ConstantExpression;
    var result = expr3.Method.Invoke(dt, new object[] { arg.Value }); //Call AddHours
-
    public class A
    {
        public string Name { set; get; }
        public DateTime DateCreated { set; get; }
    }
