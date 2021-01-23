    private static string GetFormattedErrorMessage(this Exception ex)
    {
        StringBuilder sb = new StringBuilder();
        if (ex != null)
        {
            sb.AppendLine(ex.Message);
            sb.AppendLine(ex.StackTrace);
            sb.AppendLine(ex.InnerException.GetFormattedErrorMessage());
        }
        return sb.ToString();
    }
