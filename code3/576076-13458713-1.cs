    public class MyInterceptor : EmptyInterceptor
    {
        public override int[] FindDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            var result = new List<int>();
    
            // we do not care about other entities here
            if(!(entity is Client))
            {
                return null; 
            }
    
            var length = propertyNames.Length;
            
            // iterate all properties
            for(var i = 0; i < length; i++)
            {
                var areEqual = currentState[i].Equals(previousState[i]);
                var isResettingProperty = propertyNames[i] == "Code";
    
                if (!areEqual || isResettingProperty)
                {
                    result.Add(i); // the index of "Code" property will be added always
                }
            }
    
            return result.ToArray();
        }
    }
