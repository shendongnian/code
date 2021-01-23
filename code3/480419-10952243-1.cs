	internal sealed class MyFirstCustomParameterInspector : System.ServiceModel.Dispatcher.IParameterInspector
	{
		#region IParameterInspector Members
		public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
		{
			////do stuff here
		}
		public object BeforeCall(string operationName, object[] inputs)
		{
			////or here
			return null;
		}
		#endregion
	}
