    <ListBox ItemsSource="{Binding Resources}" x:Name="List" AlternationCount="{Binding Resources.Count}">
        <ListBox.Resources>
            <sample:EqualityConverter x:Key="Converter" />
        </ListBox.Resources>
        <ListBox.ItemContainerStyle>
                <Style TargetType="{x:Type ListBoxItem}">
                <Style.Triggers>
                    <DataTrigger Value="True">
                        <DataTrigger.Binding>
                            <MultiBinding Converter="{StaticResource Converter}">
                                <Binding Path="DataContext.CurrentItem" ElementName="List"/>
                                    <Binding RelativeSource="{RelativeSource Self}" Path="(ItemsControl.AlternationIndex)"/>
                            </MultiBinding>
                        </DataTrigger.Binding>
                        <Setter Property="Background" Value="Blue"></Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ListBox.ItemContainerStyle>
    </ListBox>
