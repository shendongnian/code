    <Window x:Class="WpfApplication18.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" 
            xmlns:WpfApplication18="clr-namespace:WpfApplication18"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Grid.Resources>
                <DataTemplate DataType="{x:Type WpfApplication18:PersonsVM}">
                    <DataGrid ItemsSource="{Binding Items}" AutoGenerateColumns="False">
                        <DataGrid.Columns>
                            <DataGridTextColumn Binding="{Binding FirstName}" Header="First name"/>
                            <DataGridTextColumn Binding="{Binding LastName}" Header="Last name"/>
                        </DataGrid.Columns>
                    </DataGrid>
                </DataTemplate>
                <DataTemplate DataType="{x:Type WpfApplication18:SpecificPersonsVM}">
                    <DataGrid ItemsSource="{Binding Items}" AutoGenerateColumns="False">
                        <DataGrid.Columns>
                            <DataGridTextColumn Binding="{Binding LastName}" Header="Last name"/>
                            <DataGridTextColumn Binding="{Binding FirstName}" Header="First name"/>
                            <DataGridTextColumn Binding="{Binding Age}" Header="Age"/>
                        </DataGrid.Columns>
                    </DataGrid>
                </DataTemplate>
            </Grid.Resources>
            <ContentControl Content="{Binding}"/>
        </Grid>
    </Window>
