	public class WaitableTimer : WaitHandle
	{
		[DllImport("kernel32.dll")]
		static extern SafeWaitHandle CreateWaitableTimer(IntPtr lpTimerAttributes, bool bManualReset, string lpTimerName);
		
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool SetWaitableTimer(SafeWaitHandle hTimer, [In] ref long pDueTime, int lPeriod, IntPtr pfnCompletionRoutine, IntPtr lpArgToCompletionRoutine, bool fResume);
		
		public WaitableTimer(bool manualReset = true, string timerName = null)
		{
			this.SafeWaitHandle = CreateWaitableTimer(IntPtr.Zero, manualReset, timerName);
		}
		
		public void Set(long dueTime)
		{
			if (!SetWaitableTimer(this.SafeWaitHandle, ref dueTime, 0, IntPtr.Zero, IntPtr.Zero, false))
			{
				throw new Win32Exception();
			}
		}
	}
