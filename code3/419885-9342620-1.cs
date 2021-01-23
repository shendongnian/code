// here is your event-raising class 
using System;
using System.ComponentModel;
namespace ClassLibrary1
{
	public class Class1
	{
		public ISynchronizeInvoke EventSyncInvoke { get; set; }
		public event EventHandler TestEvent;
		private void RaiseTestEvent(EventArgs e)
		{
			// take a local copy -- this is for thread safety.  If an unsubscribe on another thread
			// causes TestEvent to become null, this will protect you from a null reference exception.
			// (the event will be raised to all subscribers as of the point in time that this line executes)
			EventHandler testEvent = this.TestEvent;
			
			// check for no subscribers
			if (testEvent == null)
				return;
			if (EventSyncInvoke == null)
				testEvent(this, e);
			else
				EventSyncInvoke.Invoke(testEvent, new object[] {this, e});
		}
		public void Test()
		{
			RaiseTestEvent(EventArgs.Empty);
		}
	}
}
// here is form that tests it -- if you run it, you will see that the event is marshalled back to
// the main thread, as desired.
using System;
using System.Threading;
using System.Windows.Forms;
namespace ClassLibrary1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.TestClass = new Class1();
			this.TestClass.EventSyncInvoke = this;
			this.TestClass.TestEvent += new EventHandler(TestClass_TestEvent);
			Thread.CurrentThread.Name = "Main";
		}
		void TestClass_TestEvent(object sender, EventArgs e)
		{
			MessageBox.Show(this, string.Format("Event.  Thread: {0} Id: {1}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId));
		}
		private Class1 TestClass;
		private void button1_Click(object sender, EventArgs e)
		{
                              // you can test with an "old fashioned" thread, or the TPL
			var t = new Thread(() => this.TestClass.Test());
			t.Start();
			//Task.Factory.StartNew(() => this.TestClass.Test());
		}
	}
}
