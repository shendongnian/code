    /// <summary>
    ///     A DbEntityValidationException extension method that formates validation errores to string.
    /// </summary>
    /// <param name="e">    The e to act on. </param>
    /// <returns>   A string. </returns>
    public static string ValidationErroresToString(this DbEntityValidationException e)
    {
        return string.Format("{0}{1}Validation errors:{1}{2}",
                             e,
                             Environment.NewLine,
                             e.EntityValidationErrors
                             .Select(ex => string.Join(Environment.NewLine, ex.ValidationErrors
                                 .Select(v => string.Format("{0} - {1}", v.PropertyName, v.ErrorMessage)))));
    }
