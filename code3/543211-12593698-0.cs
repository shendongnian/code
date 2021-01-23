    <StackPanel>
        <StackPanel>
            <Label FontSize="28" Content="Sales">
            </Label>
        </StackPanel>
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto" />
                <ColumnDefinition Width="*" />
            </Grid.ColumnDefinitions>
            <StackPanel Grid.Column="0" Width="auto" HorizontalAlignment="Center">
                <Label FontSize="15" Content="Enter Amount" Height="26" Width="168" />
                <Separator Width="168" />
            </StackPanel>
            <StackPanel Grid.Column="1">
                <Expander ExpandDirection="Left" HorizontalAlignment="Right" VerticalAlignment="Stretch">
                    <Expander.Header>
                        <TextBlock Text="More">
                    <TextBlock.LayoutTransform>
                        <RotateTransform Angle="-90"/>
                    </TextBlock.LayoutTransform>
                        </TextBlock>
                    </Expander.Header>
                    <Expander.Content>
                        <StackPanel>
                            <DataGrid ItemsSource="{Binding Products}">
                            </DataGrid>
                        </StackPanel>
                    </Expander.Content>
                </Expander>
            </StackPanel>
        </Grid>
    </StackPanel>
