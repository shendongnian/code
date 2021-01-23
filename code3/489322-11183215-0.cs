	[Serializable]
	public class OnGuiThreadAttribute : MethodInterceptionAspect
	{
		private static Control MainControl;
		public static void RegisterMainControl(Control mainControl) //or internal visibility if you prefer
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
