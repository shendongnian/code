	public interface INumberedItem : INotifyPropertyChanged
	{
		int NumberInList { get; set; }
	}
	
	public class NumberedGridView : GridView
	{
		protected override void OnItemsChanged(object e)
		{
			base.OnItemsChanged(e);
			var i = 1;
			foreach (var item in Items.OfType<INumberedItem>())
			{
				item.NumberInList = i++;
			}
		}
	}
