    public bool AbidingByRule(IDictionary rule)
             {
                 var props = this.GetType().GetProperties();
                 bool flag = true;
                 var type=this.GetType();
                 foreach (var key in rule.Keys)
                 {
                     if (rule[key] != type.GetProperty((string)key).GetValue(this, null))
                     {
                         flag = false;
                         break;
                     }
                 }
                 return flag;
             }
