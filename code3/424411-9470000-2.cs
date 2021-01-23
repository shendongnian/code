    public class FolderPath
    {
        public string Directory { get; set; }
        public string Status { get; set; }
    }
    <GridViewColumn Header="Status">
        <GridViewColumn.CellTemplate>
            <DataTemplate>
                <Image Source="{Binding Path=Status}"/>
            </DataTemplate>
        </GridViewColumn.CellTemplate>
    </GridViewColumn>
    private void button1_Click(object sender, RoutedEventArgs e)
    {                    
        ObservableCollection<FolderPath> _FolderCollection = new ObservableCollection<FolderPath>();
        listView1.Items.Add(new FolderPath { Directory = "something", Status = @"C:\Users\smk\Documents\Visual Studio 2010\Projects\Folder_locker\Folder_locker\folder_lock.ico" } )
    }
