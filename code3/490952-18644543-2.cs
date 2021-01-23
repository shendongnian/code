    public static class HandleHttpRequestValidationExceptionHelper
    {
        /// <summary>
        /// Use TryAssignment in anticipation of a HttpRequestValidationException; it's used to help return error information to the user
        /// </summary>
        /// <param name="modelStateDictionary">The ModelStateDictionary to add the errors to</param>
        /// <param name="action">The attempted value to assign</param>
        /// <returns>Either the proper value or the errored value read from the HttpRequestValidationException Message property</returns>
        public static string TryAssignment(ModelStateDictionary modelStateDictionary, Func<string> action)
        {
            try
            {
                return action();
            }
            catch (HttpRequestValidationException ex)
            {
                // in effort to better inform the user, try to fish out the offending form field
                var parenthesesMatch = Regex.Match(ex.Message, @"\(([^)]*)\)");
                if (parenthesesMatch.Success)
                {
                    var badFormInput = parenthesesMatch.Groups[1].Value.Split('=');
                    modelStateDictionary.AddModelError(badFormInput[0], badFormInput[1] + " is not valid.");
                    return badFormInput[1].TrimStart('"').TrimEnd('"');
                }
                else
                {
                    // if attempt to find the offending field fails, just give a general error
                    modelStateDictionary.AddModelError("", "Please enter valid information.");
                    return string.Empty;
                }
            }
        }
        /// <summary>
        /// Use TryAssignment in anticipation of a HttpRequestValidationException; it's used to help return error information to the user
        /// </summary>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <param name="modelStateDictionary">The ModelStateDictionary to add the errors to</param>
        /// <param name="action">The attempted value to assign</param>
        /// <returns>Either the proper value or default(T)</returns>
        public static T TryAssignment<T>(ModelStateDictionary modelState, Func<T> action)
        {
            try
            {
                return action();
            }
            catch (HttpRequestValidationException ex)
            {
                // in effort to better inform the user, try to fish out the offending form field
                var parenthesesMatch = Regex.Match(ex.Message, @"\(([^)]*)\)");
                if (parenthesesMatch.Success)
                {
                    var badFormInput = parenthesesMatch.Groups[1].Value.Split('=');
                    modelState.AddModelError(badFormInput[0], badFormInput[1] + " is not valid.");
                    // can't really cast a string to an unknown type T.  safer to just return default(T)
                }
                else
                {
                    // if attempt to find the offending field fails, just give a general error
                    modelState.AddModelError("", "Please enter valid information.");
                }
                return default(T);
            }
        }
    }
