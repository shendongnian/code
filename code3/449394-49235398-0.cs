	using System.ComponentModel;
	using System.Drawing;
	using System.Threading;
	namespace System.Windows.Forms.More
	{
	  [ToolboxBitmap(typeof(BindingSource))]
	  public class SynchronizedBindingSource : BindingSource
	  {
		#region constructors
		public SynchronizedBindingSource()
		{
		  this.SynchronizationContext = SynchronizationContext.Current;
		}
		public SynchronizedBindingSource(IContainer container)
		  : this()
		{
		  container?.Add(this);
		}
		#endregion
		
		/// <summary>
		/// Changed events of binding source will be called from this synchronization context
		/// This is initialized at constructor
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public SynchronizationContext SynchronizationContext { get; set; }
		#region thread safe events
		protected override void OnAddingNew(AddingNewEventArgs e)
		{
		  this.InvokeOnUiThread(() => base.OnAddingNew(e));
		}
		protected override void OnBindingComplete(BindingCompleteEventArgs e)
		{
		  this.InvokeOnUiThread(() => base.OnBindingComplete(e));
		}
		protected override void OnCurrentChanged(EventArgs e)
		{
		  this.InvokeOnUiThread(() => base.OnCurrentChanged(e));
		}
		protected override void OnCurrentItemChanged(EventArgs e)
		{
		  this.InvokeOnUiThread(() => base.OnCurrentItemChanged(e));
		}
		protected override void OnDataError(BindingManagerDataErrorEventArgs e)
		{
		  this.InvokeOnUiThread(() => base.OnDataError(e));
		}
		protected override void OnDataMemberChanged(EventArgs e)
		{
		  this.InvokeOnUiThread(() => base.OnDataMemberChanged(e));
		}
		protected override void OnDataSourceChanged(EventArgs e)
		{
		  this.InvokeOnUiThread(() => base.OnDataSourceChanged(e));
		}
		protected override void OnListChanged(ListChangedEventArgs e)
		{
		  this.InvokeOnUiThread(() => base.OnListChanged(e));
		}
		protected override void OnPositionChanged(EventArgs e)
		{
		  this.InvokeOnUiThread(() => base.OnPositionChanged(e));
		}
		private void InvokeOnUiThread(Action action)
		{
		  this.SynchronizationContext?.Post(o => action(), null);
		}
		#endregion
	  }
	}
