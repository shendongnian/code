    public static string LambdaToString<T>(Expression<Func<T, bool>> expression, string value,string paramName )
            {
              
                string body = expression.Body.ToString().Replace(paramName,value);
         
                foreach (var parm in expression.Parameters)
                {
                    var parmName = parm.Name;
                   
                    var parmTypeName = parm.Type.Name;
                    body = body.Replace(parmName + ".", parmTypeName + ".");
                }
                return body;
            }
