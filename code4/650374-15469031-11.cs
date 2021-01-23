     <DataGrid x:Name="grid" local:DataGridTextSearch.SearchValue="{Binding ElementName=SearchBox, Path=Text, UpdateSourceTrigger=PropertyChanged}" 
                  ItemsSource="{Binding TestData}" >
            <DataGrid.Resources>
                <local:SearchValueConverter x:Key="SearchValueConverter" />
                <Style TargetType="{x:Type DataGridRow}">
                    <Setter Property="local:DataGridTextSearch.IsTextMatch">
                        <Setter.Value>
                            <MultiBinding Converter="{StaticResource SearchValueConverter}">
                                <Binding RelativeSource="{RelativeSource Self}" Path="DataContext.MyProperty" />
                                <Binding RelativeSource="{RelativeSource Self}" Path="(local:DataGridTextSearch.SearchValue)" />
                            </MultiBinding>
                        </Setter.Value>
                    </Setter>
                    <Style.Triggers>
                        <Trigger Property="local:DataGridTextSearch.IsTextMatch" Value="True">
                            <Setter Property="IsSelected" Value="True" />
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </DataGrid.Resources>
        </DataGrid>
