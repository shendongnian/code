    /// <summary>
    ///     A DbEntityValidationException extension method that formates validation errores to string.
    /// </summary>
    /// <param name="e">    The e to act on. </param>
    /// <returns>   A string. </returns>
    public static string ValidationErrorsToString(this DbEntityValidationException e)
    {
        var aggregatedMsgs = e.EntityValidationErrors.SelectMany(dbEntityValidationResult => dbEntityValidationResult.ValidationErrors)
                              .Aggregate(string.Empty, (c, v) => c + string.Format("{0}{1}{2} - {3}", c, Environment.NewLine, v.PropertyName, v.ErrorMessage));
        var msg = string.Format("{0}{1}Validation errors:{1}{2}", e, Environment.NewLine, aggregatedMsgs);
        return msg;
    }
