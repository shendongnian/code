cs
public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
{
	double result = 0.0;
	foreach (object item in values)
	{
		result += System.Convert.ToDouble(item);
	}
	return result;
}
public object[] ConvertBack(object values, Type[] targetType, object parameter, CultureInfo culture)
{
	return null;
}
Everytime you expand a control, its ActualHeight changes and the Binding gets update -> MinHeight of the parents RowDefinition changes.
But you cant set one if the controls VerticalAlignment to Stretch, because then the ActualHeight wouldn't change by expanding.
**EDIT**: Since the only property I can now think of is the DesiredSize.Height-property, you can't use Binding (the binding won't update, if the DesiredSize.Height-value changes).
But perhaps you can use a property (let's call it MinHeightRowOne) of type double which raises the PropertyChanged event in it's setter and is bound to the first rows MinHeight (one property for each row):
cs
public double _minHeightRowOne;
public double MinHeightRowOne
{
	get
	{
		return _minHeightRowOne;
	}
	set
	{
		_minHeightRowOne = value;
		OnPropertyChanged("MinHeightRowOne");
	}
}
public event PropertyChangedEventHandler PropertyChanged;
public void OnPropertyChanged(string name)
{
	if (PropertyChanged != null)
	{
		PropertyChanged(this, new PropertyChangedEventArgs(name));
	}
}
<br/>
<RowDefinition Height="100" MinHeight="{Binding Path=MinHeightRowOne}"/>
Now add this EventHandler to the SizeChanged-Event of every control in the first row (one handler for each row):
cs
private List<KeyValuePair<string,double>> oldVals = new List<KeyValuePair<string,double>>();
private void ElementInRowOneSizeChanged(object sender, SizeChangedEventArgs e)
{
	FrameworkElement elem = (FrameworkElement)sender;
	MinHeightRowOne -= oldVals.Find(kvp => kvp.Key == elem.Name).Value;
	elem.Measure(new Size(int.MaxValue, int.MaxValue));
	MinHeightRowOne += elem.DesiredSize.Height;
	oldVals.Remove(oldVals.Find(kvp => kvp.Key == elem.Name));
	oldVals.Add(new KeyValuePair<string, double>(elem.Name, elem.DesiredSize.Height));
}
Through this the MinHeight of the Rows get updated everytime the Size of a control changes (which should include expanding or collapsing items).
Note that every control must have an unique name to make this work.
