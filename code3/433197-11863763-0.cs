[TestMethod]
public void Properties_WhenSet_TriggerNotifyPropertyChanged()
{
    new NotifyPropertyChangedTester(new FooViewModel()).Test();
}
