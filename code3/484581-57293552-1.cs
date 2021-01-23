    using System;
    using System.Windows.Threading;
    namespace Yournamespace
    {
        public partial class TestTimer
        {
            DispatcherTimer dispatcherTimer1m;
            public TestTimer()
            {
                dispatcherTimer1m = new  DispatcherTimer();
                dispatcherTimer1m.Tick += new EventHandler(DispatcherTimer1m_Tick);
                dispatcherTimer1m.Interval = TaskHelper.GetSyncIntervalms;
                dispatcherTimerm.Start();
            }
            private void DispatcherTimer1m_Tick(object sender, EventArgs e)
            {
                try
                {
                dispatcherTimer1m.Stop();           
				//Do your effort here
            }
            catch (Exception exc)
            {
					//Your exception handled here
			}
            finally
            {  
                dispatcherTimer1m.Interval = TaskHelper.GetSyncInterval1m;
                dispatcherTimer1m.Start();
                }
            }   
        }
        public class TaskHelper
        {
            private const ushort internalUpdate = 15;//ms        
            public static TimeSpan GetSyncInterval1m => new TimeSpan(0, 0, 0, 60,internalUpdate).Subtract( new TimeSpan(0, 0, 0, DateTime.Now.Second, 0));
	    }
    }
   
