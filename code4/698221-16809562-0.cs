myCollectionViewSource.View.Filter = new Predicate<object>(this.MyFilter);
public bool MyFilter(string item)
{
  // put whatever filtering logic you have in here
  return item.StartsWith(myTextBox.Text);
}
</pre>
