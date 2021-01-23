    String columName; //your dynamic columnName
    if(operator == Operator.LesserThan)
            {
                 query = entities.Where(o => o.GetType().GetProperty(columName).GetValue(o, null) <columName);
            }
            else if (operator == Operator.GreaterThan)
            {
                etc.
            }
       
