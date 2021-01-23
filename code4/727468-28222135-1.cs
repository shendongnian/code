       /// <summary>
    /// Helps find an overloaded method
    /// </summary>
    public static class OverloadedMethodFinder
    {
        #region Public Static Methods
        /// <summary>
        /// Attempts to find the overloaded method that we want to call. Returns null if not found. This overload looks at the parameter types passed in vs method parameters off of the type we pass in
        /// </summary>
        /// <param name="MethodNameToRetrieve">What is the method to name to find</param>
        /// <param name="TypeToLookThroughTheMethods">The type to retrieve the methods off of, so we can look through it and try to find the correct method</param>
        /// <param name="MethodParameterTypes">Look for the method parameter types in the method to match. If the method takes a string and an int, then we will look for that in every method</param>
        /// <returns>Method info found, or null value if not found</returns>
        public static MethodInfo FindOverloadedMethodToCall(string MethodNameToRetrieve, Type TypeToLookThroughTheMethods, params Type[] MethodParameterTypes)
        {
            //going to use the overload. So we can create the func with calling the other method
            return FindOverloadedMethodToCall(MethodNameToRetrieve, TypeToLookThroughTheMethods, x => MethodParameterSelector(x, MethodParameterTypes));
        }
        /// <summary>
        /// Attempts to find the overloaded method that we want to call. Returns null if not found. This method will try to evaluate the MethodSelect for each method and check to see if it returns true.
        /// </summary>
        /// <param name="MethodNameToRetrieve">What is the method to name to find</param>
        /// <param name="MethodSelector">Gives the calling method the ability to look through the parameters and pick the correct method</param>
        /// <param name="TypeToLookThroughTheMethods">The type to retrieve the methods off of, so we can look through it and try to find the correct method</param>
        /// <returns>Method info found, or null value if not found</returns>
        public static MethodInfo FindOverloadedMethodToCall(string MethodNameToRetrieve, Type TypeToLookThroughTheMethods, Func<MethodInfo, bool> MethodSelector)
        {
            //use the overload
            return FindOverloadedMethodToCall(MethodNameToRetrieve, TypeToLookThroughTheMethods.GetMethods(), MethodSelector);
        }
        /// <summary>
        /// Attempts to find the overloaded method that we want to call. Returns null if not found. This method will try to evaluate the MethodSelect for each method and check to see if it returns true.
        /// Call this method if you already have the method info's that match the same name you are looking for
        /// </summary>
        /// <param name="MethodNameToRetrieve">What is the method to name to find</param>
        /// <param name="MethodSelector">Gives the calling method the ability to look through the parameters and pick the correct method</param>
        /// <param name="MethodsToLookThrough">Methods that have the same name. Or methods to loop through and inspect against the method selector.</param>
        /// <returns>Method info found, or null value if not found</returns>
        public static MethodInfo FindOverloadedMethodToCall(string MethodNameToRetrieve, IEnumerable<MethodInfo> MethodsToLookThrough, Func<MethodInfo, bool> MethodSelector)
        {
            //let's start looping through the methods to see if we can find a match
            foreach (MethodInfo MethodToInspect in MethodsToLookThrough)
            {
                //is it the method name? and does it match the method selector passed in?
                if (string.Equals(MethodNameToRetrieve, MethodToInspect.Name, StringComparison.OrdinalIgnoreCase) && MethodSelector(MethodToInspect))
                {
                    //we have a match...return the method now
                    return MethodToInspect;
                }
            }
            //we never found a match, so just return null
            return null;
        }
        #endregion
        #region Private Static Methods
        /// <summary>
        /// Private helper method to look at the current method and inspect it for the method parameter types. If they match return true, else return false
        /// </summary>
        /// <param name="MethodToEvaluate">Method to evaluate and check if we have a match based on the method parameter types</param>
        /// <param name="MethodParameterTypes"></param>
        /// <returns>Do we have a match? Do the method parameter types match?</returns>
        private static bool MethodParameterSelector(MethodInfo MethodToEvaluate, params Type[] MethodParameterTypes)
        {
            //we are going to match the GetParameters and the MethodParameterTypes. It needs to match index for index and type for type. So GetParameters[0].Type must match MethodParameterTypes[0].Type...[1].Type must match [1].Type
            //holds the index with the method parameter types we are up too
            int i = 0;
            //let's loop through the parameters
            foreach (ParameterInfo thisParameter in MethodToEvaluate.GetParameters())
            {
                //it's a generic parameter...ie...TSource then we are going to ignore it because whatever we pass in would be TSource
                if (!thisParameter.ParameterType.IsGenericParameter)
                {
                    //is this a generic type? we need to compare this differently
                    if (thisParameter.ParameterType.IsGenericType)
                    {
                        //is the method parameter a generic type?
                        if (!MethodParameterTypes[i].IsGenericType)
                        {
                            //it isn't so return false..cause they aren't the same
                            return false;
                        }
                        //if the generic type's don't match then return false...This might be problematic...it works for the scenario which I'm using it for so we will leave this and modify afterwards
                        if (thisParameter.ParameterType.GetGenericTypeDefinition() != MethodParameterTypes[i].GetGenericTypeDefinition())
                        {
                            //doesn't match return false
                            return false;
                        }
                    }
                    else if (thisParameter.ParameterType != MethodParameterTypes[i].UnderlyingSystemType)
                    {
                        //this is a regular parameter so we can compare it normally
                        //we don't have a match...so return false
                        return false;
                    }
                }
                //increment the index
                i++;
            }
            //if we get here then everything matches so return true
            return true;
        }
        #endregion
    }
