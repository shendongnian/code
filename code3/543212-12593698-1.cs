    <StackPanel>
        <StackPanel>
            <Label FontSize="28" Content="Sales">
            </Label>
        </StackPanel>
        <Grid>
            <Grid.ColumnDefinitions>                
                <ColumnDefinition Width="*" />
                <ColumnDefinition Width="Auto" />
            </Grid.ColumnDefinitions>
            <StackPanel Grid.Column="0" HorizontalAlignment="Center">
                <Label FontSize="15" Content="Enter Amount" Height="26" Width="168" />
                <Separator Width="168" />
            </StackPanel>
            <Expander Grid.Column="1" ExpandDirection="Left" HorizontalAlignment="Right" VerticalAlignment="Stretch">
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
        </Grid>
    </StackPanel>
