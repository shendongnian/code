    <UserControl x:Class="MCSearchMVVM.AddFilePage"    
             ...
             xmlns:local="clr-namespace:MCSearchMVVM"
             ...>
    
    <UserControl.Resources>
        <local:MCBindButtonToComboBox x:Key="enableCon"/>
    </UserControl.Resources>
    
    <Grid>
        <Grid.ColumnDefinitions>
           ...
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            ...
        </Grid.RowDefinitions>
        <Grid.Background>
            ...
        </Grid.Background>
       
        <Button Content="Browse.." 
                ...
                Command="{Binding BrowseCommand}"          
                IsEnabled="{Binding FileKindIndexSelected,
                            Converter={StaticResource enableCon}}"
                .../>
        <ComboBox ... SelectedIndex="{Binding FileKindIndexSelected, Mode=TwoWay}" ... >
            ...
        </ComboBox>
       ...
    </Grid>
