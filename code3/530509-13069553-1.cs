	public class ExtendedQueryStringBehavior : WebHttpBehavior
	{
		protected override QueryStringConverter GetQueryStringConverter(OperationDescription operationDescription)
		{
			return new ExtendedQueryStringConverter();
		}
	}
