            <TabItem Header="XAML" IsSelected="{Binding DisplayXamlTab, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
                <Grid Background="#FFE5E5E5">
                    <TextBox x:Name="TxtXamlOutput" IsReadOnly="True" Text="{Binding XamlText, Mode=TwoWay, NotifyOnTargetUpdated=True, NotifyOnSourceUpdated=True, UpdateSourceTrigger=PropertyChanged}" AcceptsReturn="True" TextWrapping="Wrap" VerticalScrollBarVisibility="Visible"/>
                </Grid>
            </TabItem>
