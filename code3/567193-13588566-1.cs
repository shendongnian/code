    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="GridView">
                <Border BorderBrush="{TemplateBinding BorderBrush}"
                        BorderThickness="{TemplateBinding BorderThickness}"
                        Background="{TemplateBinding Background}">
                    <ScrollViewer x:Name="ScrollViewer">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="50" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
                            <!-- Your custom buttons -->
                            <StackPanel Orientation="Vertical"
                                        Grid.Column="0">
                                
                            </StackPanel>
                            <ItemsPresenter Grid.Column="1"
                                            HeaderTemplate="{TemplateBinding HeaderTemplate}"
                                            Header="{TemplateBinding Header}"
                                            HeaderTransitions="{TemplateBinding HeaderTransitions}"
                                            Padding="{TemplateBinding Padding}" />
                        </Grid>
                    </ScrollViewer>
                </Border>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
