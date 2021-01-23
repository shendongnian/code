                <ListView Name="lstView" ItemsSource="{Binding Path=SimResults}" >
                    <ListView.ItemTemplate>
                        <DataTemplate>
                            <Grid>
                                <i:Interaction.Triggers>
                                    <i:EventTrigger EventName="SelectionChanged">
                                        <i:InvokeCommandAction Command="{Binding SelectedItemCommand}" CommandParameter="{Binding SelectedItem, ElementName=lstView}" />
                                    </i:EventTrigger>
                                </i:Interaction.Triggers>
                            </Grid>
                        </DataTemplate>
                    </ListView.ItemTemplate>
                    <ListView.View>
                        <GridView>
                            <GridView.Columns>
                                <GridViewColumn Header="FileUniqueID"   Width="100" DisplayMemberBinding="{Binding Path=Name}" />
                                <GridViewColumn Header="XML" Width="100" DisplayMemberBinding="{Binding Path=XML}" />
                                <GridViewColumn Header="Request" Width="100" HeaderStringFormat="" DisplayMemberBinding="{Binding Path=RequestShort}" />
                                <GridViewColumn Header="RequestDate" Width="100" DisplayMemberBinding="{Binding Path=RequestDate}" />
                                <GridViewColumn Header="Response" Width="100" DisplayMemberBinding="{Binding Path=ResponseShort}" />
                                <GridViewColumn Header="ResponseDate" Width="100" DisplayMemberBinding="{Binding Path=ResponseData}" />
                            </GridView.Columns>
                        </GridView>
                    </ListView.View>
                </ListView>
