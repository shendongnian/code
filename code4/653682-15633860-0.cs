    <ListBox Name="listBox">
        <ListBox.ItemTemplate >
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <xctk:DateTimePicker Value="{Binding Start}" Format="ShortTime" />
                    <xctk:DateTimePicker Value="{Binding End}" Format="ShortTime" />
                </StackPanel>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
    public class TimePeriod
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    void Window_Loaded(object sender, RoutedEventArgs e)
    {
        ObservableCollection<TimePeriod> collection = new ObservableCollection<TimePeriod>();
        collection.Add(new TimePeriod {Start = DateTime.Now - TimeSpan.FromHours(5), End = DateTime.Now});
        collection.Add(new TimePeriod {Start = DateTime.Now, End = DateTime.Now + TimeSpan.FromHours(5)});
        listBox.ItemsSource = collection;
    }
