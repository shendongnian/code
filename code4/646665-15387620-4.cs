    namespace Demo.Utilities
    {
        internal class Helper
        {
            internal static Guid GetCorrelationId()
            {
                var headerPosition = OperationContext.Current.IncomingMessageHeaders.FindHeader("ActivityId",
                    "http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics");
                if (headerPosition > -1)
                {
                    var activityIdHeader = OperationContext.Current.IncomingMessageHeaders
                        .GetReaderAtHeader(headerPosition);
                    var activityIdAttribute = activityIdHeader.GetAttribute("CorrelationId");
                    return Guid.Parse(activityIdAttribute);
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }
    }
