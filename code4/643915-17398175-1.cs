    public class SlidingItem
    {
	public SlidingItem(string text, int number)
	{
		Text = text;
		Number = number;
		TimeStamp = DateTime.Now;
		Id = ++ItemsProcessed;
	}
	private static int _itemsProcessed;
	public int ItemsProcessed
	{
		get { return _itemsProcessed; }
		set { _itemsProcessed = value; }
	}
	public int Id { get; set; }
	public string Text { get; set; }
	public int Number { get; set; }
	public DateTime TimeStamp { get; set; }
	public string ShowMembers()
	{
		return string.Format("{0}\t{1}\t{2}\t{3}", TimeStamp.ToString("G", CultureInfo.CurrentCulture), Number, Text, Id);
	}
	public override string ToString()
	{
		return ShowMembers();
	}
    }
