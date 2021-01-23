    ////DataItem.cs
    public class DataItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string[] GroupProperties { get; set; }
    }
    ////MainWindow.xaml.cs
    public partial class MainWindow : Window
    {
        public ObservableCollection<DataItem> DataList { get; set; }
        public MainWindow()
        {
            DataList = new ObservableCollection<DataItem>(new DataItem[] { 
                new DataItem(){ Name = "1111", Path = "C:\\1111", GroupProperties = new string[]{"HeNan", "JiangSu", "BeiJing"} },
                new DataItem(){ Name = "2222", Path = "C:\\2222", GroupProperties = new string[]{"HeNan", "TianJin", "ShenZhen"} },
                new DataItem(){ Name = "3333", Path = "C:\\1111", GroupProperties = new string[]{"GuangZhou", "XiAn", "BeiJing"} },
                new DataItem(){ Name = "4444", Path = "C:\\4444", GroupProperties = new string[]{"HeNan", "NanJing", "KunMing"} }
            });
            InitializeComponent();           
            
        }
    }
     ////MainWindow.xaml
    <Window x:Class="CultureDemo.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:scm="clr-namespace:System.ComponentModel;assembly=WindowsBase"
        Title="MainWindow" Height="350" Width="525" DataContext="{Binding RelativeSource={RelativeSource Self}}">
    <Window.Resources>
        <CollectionViewSource x:Key="ListBoxSource2" Source="{Binding DataList}">
            <CollectionViewSource.SortDescriptions>
                <scm:SortDescription Direction="Descending" PropertyName="Name">                    
                </scm:SortDescription>
            </CollectionViewSource.SortDescriptions>
            <CollectionViewSource.GroupDescriptions>
                <PropertyGroupDescription PropertyName="Path" StringComparison="OrdinalIgnoreCase"></PropertyGroupDescription>
            </CollectionViewSource.GroupDescriptions>
        </CollectionViewSource>
        
        <CollectionViewSource x:Key="ListBoxSource3" Source="{Binding DataList}">
            <CollectionViewSource.SortDescriptions>
                <scm:SortDescription Direction="Ascending" PropertyName="Name">                    
                </scm:SortDescription>
            </CollectionViewSource.SortDescriptions>
            <CollectionViewSource.GroupDescriptions>
                <PropertyGroupDescription PropertyName="GroupProperties" StringComparison="OrdinalIgnoreCase"></PropertyGroupDescription>
            </CollectionViewSource.GroupDescriptions>
        </CollectionViewSource>
        
    </Window.Resources>
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="180*" />
            <ColumnDefinition Width="169*" />
            <ColumnDefinition Width="154*" />
        </Grid.ColumnDefinitions>
        <ListBox Name="listBox1" ItemsSource="{Binding DataList}" DisplayMemberPath="Name">
        </ListBox>
        <ListBox Grid.Column="1" Name="listBox2" ItemsSource="{Binding Source={StaticResource ListBoxSource2}}" >
            <ListBox.GroupStyle>
                <GroupStyle>
                    
                </GroupStyle>
            </ListBox.GroupStyle>
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Name}"></TextBlock>
                </DataTemplate>
            </ListBox.ItemTemplate>            
        </ListBox>
        <ListBox Grid.Column="2" Name="listBox3"  ItemsSource="{Binding Source={StaticResource ListBoxSource3}}">
            <ListBox.GroupStyle>
                <GroupStyle>
                    
                </GroupStyle>
            </ListBox.GroupStyle>
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Name}"></TextBlock>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Grid>
    </Window>
