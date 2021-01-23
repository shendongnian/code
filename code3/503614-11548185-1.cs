        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition />
                <ColumnDefinition Width="*" />
            </Grid.ColumnDefinitions>
            <TextBox Grid.Column="0" Text="{Binding Department, UpdateSourceTrigger=PropertyChanged}" />
            <ListView ItemsSource="{Binding People}" Grid.Column="1">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Vertical" Margin="0,0,0,15">
                            <TextBlock Text="{Binding Department}"/>
                            <TextBlock>
                                <TextBlock.Text>
                                    <MultiBinding StringFormat="{}{0} {1}">
                                       <Binding Path="FirstName"/>
                                       <Binding Path="LastName"/>
                                     </MultiBinding> 
                                </TextBlock.Text>
                            </TextBlock>
                        </StackPanel>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </Grid>
