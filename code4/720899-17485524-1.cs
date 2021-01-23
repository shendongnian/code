    public class ResponseDataFilterHandler : DelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken)
                .ContinueWith(task =>
                {
                    var response = task.Result;
                    //Manipulate content here
                    var content = response.Content as ObjectContent;
                    if (content != null && content.Value != null)
                    {
                        FilterFields(content.Value);
                    }
                    return response;
                });
        }
        private void FilterFields(object objectToFilter)
        {
            var properties = objectToFilter
                                 .GetType()
                                 .GetProperties(
                                     BindingFlags.IgnoreCase |
                                     BindingFlags.GetProperty |
                                     BindingFlags.Instance |
                                     BindingFlags.Public);
            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.GetCustomAttributes(typeof(SensitiveAttribute), true).Any())
                {
                    propertyInfo.SetValue(objectToFilter, null, new object[0]);
                }
            }   
        }
    }
