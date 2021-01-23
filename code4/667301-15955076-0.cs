    public class PermissionViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public bool HasPermission { get; set; }
    }
    public class RoleViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public ObservableCollection<PermissionViewModel> PermissionViewModels { get; set; }
    }
    <ListBox             
    ...
    ItemsSource="{Binding SelectedRoleViewModel.PermissionViewModels}">
    <ListBox.ItemTemplate>
        <DataTemplate>
            <CheckBox Content="{Binding Name}" 
                      IsChecked="{Binding HasPermission, Mode=TwoWay}"/>
        </DataTemplate>
    </ListBox.ItemTemplate>
    
