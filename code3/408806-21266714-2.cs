    internal static class WsdlAnnotator
    {
        internal static string Annotate(string xml)
        {
            XDocument document = XDocument.Parse(xml);
            try
            {
                // Your magic here.
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    ex.Message + " Document: " + document.ToString(), ex);
            }
            return document.ToString(SaveOptions.None);
        }
