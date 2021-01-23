    // using System;
    // using System.Linq;
    // using System.Reflection;
    static Type GetCaughtTypeOfCatchClauseWithoutTypeSpecification()
    {
        try
        {
            return MethodBase
                   .GetCurrentMethod()
                   .GetMethodBody()
                   .ExceptionHandlingClauses
                   .Where(clause => clause.Flags == ExceptionHandlingClauseOptions.Clause)
                   .Select(clause => clause.CatchType)
                   .Single();
        }
        catch // <-- this is what the above code is inspecting
        {
            throw;
        }
    }
