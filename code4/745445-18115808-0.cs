    <DataGridTemplateColumn>
        <DataGridTemplateColumn.Template>
            <DataTemplate>
                <TextBlock Text="{Binding KeyIndex, NotifyOnSourceUpdated=True, Mode=OneWay}">
                    <TextBlock.Style>
                        <Style TargetType="TextBlock">
                            <Style.Triggers>
                                <EventTrigger RoutedEvent="Binding.SourceUpdated">
                                    ...
                                </EventTrigger>
                            </Style.Triggers>
                        </Style>
                    </TextBlock.Style>
                </TextBlock>
            </DataTemplate>
        </DataGridTemplateColumn.Template>
    </DataGridTemplateColumn>
