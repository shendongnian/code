     public bool AbidingByRule(IDictionary rule)
             {
                 var properties = this.GetType().GetProperties();
                 int unMatchedCount=properties.Count(p=>rule[p.Name]!=null && !rule[p.Name].Equals(p.GetValue(this,null)));
                 return unMatchedCount == 0;
             }
