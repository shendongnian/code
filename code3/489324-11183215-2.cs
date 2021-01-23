	[Serializable]
	public class OnGuiThreadAttribute : MethodInterceptionAspect
	{
		private static Control MainControl;
		//or internal visibility if you prefer
		public static void RegisterMainControl(Control mainControl) 
		{
			MainControl = mainControl;
		}
		public override void OnInvoke(MethodInterceptionArgs eventArgs)
		{
			if (MainControl.InvokeRequired)
				MainControl.BeginInvoke(eventArgs.Proceed);
			else
				eventArgs.Proceed();
		}
	}
