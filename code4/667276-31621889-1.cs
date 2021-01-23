           catch (PythonParseException)
            {
                // not valid python, try next expression
                continue;
            }
           if (compiled != null)
           {
            dynamic r = pythonEngine.Evaluate(compiled);
            String result = r.ToString(); //  Action.cs: line 217, wrapped at  ActionTest.cs: line 96
            str = str.Replace(expression.Template, result);
           }
           else
           {
               str="Exception Caught";
           }
           break;
