     public bool AbidingByRule(Dictionary<string,object> rule)
             {
                 var type=this.GetType();
                 int unmatchedCount=rule.Count(r => !r.Value.Equals(type.GetProperty(r.Key).GetValue(this, null)));
                 return unmatchedCount == 0;
             }
