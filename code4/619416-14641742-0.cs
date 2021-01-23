    <Window x:Class="DataGridWithMultipleTypesPerColumn.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <DataGrid ItemsSource="{Binding ControlTypes}"
                  AutoGenerateColumns="False">
            <DataGrid.Columns>
            <DataGridTextColumn Header="Control Type" Binding="{Binding}"/>
                <DataGridTemplateColumn Header="Actual Control">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <ContentControl>
                                <ContentControl.Style>
                                    <Style TargetType="ContentControl">
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding}" Value="TextBox">
                                                <Setter Property="ContentTemplate">
                                                    <Setter.Value>
                                                        <DataTemplate>
                                                            <TextBox Text="Default Text"/>
                                                        </DataTemplate>
                                                    </Setter.Value>
                                                </Setter>
                                            </DataTrigger>
                                            <DataTrigger Binding="{Binding}" Value="CheckBox">
                                                <Setter Property="ContentTemplate">
                                                    <Setter.Value>
                                                        <DataTemplate>
                                                            <CheckBox Content="Check Box"/>
                                                        </DataTemplate>
                                                    </Setter.Value>
                                                </Setter>
                                            </DataTrigger>
                                            <DataTrigger Binding="{Binding}" Value="Button">
                                                <Setter Property="ContentTemplate">
                                                    <Setter.Value>
                                                        <DataTemplate>
                                                            <Button Content="Button"/>
                                                        </DataTemplate>
                                                    </Setter.Value>
                                                </Setter>
                                            </DataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </ContentControl.Style>
                            </ContentControl>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
