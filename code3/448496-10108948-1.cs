    <DataTemplate x:Key="CommandsTemplate">
        <ItemsControl ItemsSource="{Binding}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel Orientation="Horizontal" />
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <ToggleButton Command="{Binding Path=Command}" Content="{Binding Path=DisplayName}" Template="{Utilities:BindableResource {Binding Path=TemplateResource}}">
                        <ToggleButton.Style>
                            <Style TargetType="ToggleButton">
                                <Style.Triggers>
                                    <Trigger Property="IsChecked" Value="True">
                                        <Setter Property="Template" Value="{Utilities:BindableResource {Binding DataContext.SelectedTemplateResource}}">
                                    </Trigger>
                                </Style.Triggers>
                            </Style>
                        </ToggleButton.Style>
                    </ToggleButton>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </DataTemplate>
