    <Grid>
            <Grid.Resources>
                <XmlDataProvider x:Key="Data">
                    <x:XData>
                        <Data xmlns="">
                            <Item ID="1"/>
                            <Item ID="2"/>
                            <Item ID="3"/>
                        </Data>
                    </x:XData>
                </XmlDataProvider>
            </Grid.Resources>
            
            <ScrollViewer>
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*"/>
                    <ColumnDefinition Width="3"/>
                    <ColumnDefinition Width="*"/>
                </Grid.ColumnDefinitions>
                    
                <ListView DataContext="{Binding Source={StaticResource Data}, XPath=/Data}"
                          ItemsSource="{Binding XPath=Item}" SelectionMode="Single">                  
                    <ListView.View>
                        <GridView>
                            <GridViewColumn Header="ID" DisplayMemberBinding="{Binding XPath=@ID}"/>
                        </GridView>
                    </ListView.View>
                </ListView>
    
                <GridSplitter Grid.Column="1" Width="3" VerticalAlignment="Stretch" HorizontalAlignment="Center" Background="Transparent" ResizeBehavior="PreviousAndNext"/>
    
    
                <TextBlock Text="Test" Grid.Column="2"/>
            </Grid>
            </ScrollViewer>
        </Grid>
