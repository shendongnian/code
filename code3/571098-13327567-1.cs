     <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="30" />
                <RowDefinition Height="*" />
            </Grid.RowDefinitions>
            
            <StackPanel Orientation="Horizontal">
                <TextBox Text="{Binding SearchString}" Width="150" />
                <Button Content="Search" Command="{Binding SearchPerson}" />
            </StackPanel>
            
            <ListView Grid.Row="1" ItemsSource="{Binding People}">
                <ListView.View>
                    <GridView>
                        <GridView.Columns>
                            <GridViewColumn Header="Name" DisplayMemberBinding="{Binding Name}" />
                            <GridViewColumn Header="Surname" DisplayMemberBinding="{Binding Surname}" />
                        </GridView.Columns>
                    </GridView>
                </ListView.View>
            </ListView>
        </Grid>
