       <ListView Name="selectedPeople"
                      Width="480"
                      Height="200"
                      HorizontalAlignment="Right"
                      VerticalAlignment="Top"
                      ItemsSource="{Binding Path=Maps,
                                            RelativeSource={RelativeSource AncestorType=Window},
                                            Mode=OneWay}">
                <ListView.View>
                    <GridView AllowsColumnReorder="True" ColumnHeaderToolTip="Broadcast call targets">
                        <GridViewColumn DisplayMemberBinding="{Binding Path=Key}" Header="ID" />
                        <GridViewColumn DisplayMemberBinding="{Binding Path=Value}" Header="Description" />
                        <GridViewColumn Header="">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <Button Content=" X " IsEnabled="{Binding RelativeSource={RelativeSource AncestorType={x:Type ListViewItem}}, Path=IsSelected}" />
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                    </GridView>
                </ListView.View>
            </ListView>
  
      public partial class Listviewsamples : Window
        {
            public Listviewsamples()
            {
                InitializeComponent();
    
                Maps = new ObservableCollection<Dictionary<string, string>>();
    
                for (int i = 0; i < 10; i++)
                {
                    Dictionary<string, string> item = new Dictionary<string, string>();
                    item.Add(i.ToString(), " Item " + i.ToString());
                    Maps.Add(item);
                }
                this.DataContext = this;
            }
            public ObservableCollection<Dictionary<string, string>> Maps { get; set; }
    
          
        }
