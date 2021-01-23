    <Window
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:System="clr-namespace:System;assembly=mscorlib" x:Class="TestStackoverflow.MainWindow"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Grid>
                <Grid.Resources>
                    <!--DataTemplate for Published Date column defined in Grid.Resources.  PublishDate is a property on the ItemsSource of type DateTime -->
                    <DataTemplate x:Key="DateTemplate" >
                        <DataGrid AutoGenerateColumns="False" >
                            <DataGrid.Columns>
                                <DataGridTextColumn Header="Second grid column" Binding="{Binding ''}" ClipboardContentBinding="{x:Null}"/>
                            </DataGrid.Columns>
                            <System:String>I heard you like</System:String>
                            <System:String>datagrids so</System:String>
                            <System:String>I put a datagrid in</System:String>
                            <System:String>your data datagrid</System:String>
                            <System:String>so you can grid while you grid.</System:String>
                        </DataGrid>
                    </DataTemplate>
                </Grid.Resources>
                <DataGrid AutoGenerateColumns="False" >
                    <DataGrid.Columns>
                        <DataGridTemplateColumn Header="Original Datagrid DG Column" CellTemplate="{StaticResource DateTemplate}" />
                        <DataGridTextColumn Header="Original Datagrid Text Column" Binding="{Binding ''}" ClipboardContentBinding="{x:Null}"/>
                    </DataGrid.Columns>
                    <System:String>String 1</System:String>
                    <System:String>String 2</System:String>
                    <System:String>String 3</System:String>
                    <System:String>String 4</System:String>
                    <System:String>String 5</System:String>
                </DataGrid>
            </Grid>
        </Grid>
    </Window>
