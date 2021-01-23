    <ListView Name="LstGrd" HorizontalAlignment="Stretch" VerticalAlignment="Stretch">
        <ListView.View>
            <GridView  >
                <GridViewColumn Header="">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <CheckBox IsChecked="{Binding IsSelected}" />
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
                <GridViewColumn Header=" Name" Width="120" DisplayMemberBinding="{Binding Path=Name}" />
                <GridViewColumn Header=" Address" Width="250" DisplayMemberBinding="{Binding Path=Address}" />
                <GridViewColumn Header=" City" Width="50" DisplayMemberBinding="{Binding Path=City}" />
                <GridViewColumn Header=" State" Width="75" DisplayMemberBinding="{Binding Path=State}" />
                <GridViewColumn Header=" PostalCode" Width="75" DisplayMemberBinding="{Binding Path=PostalCode}" />
                <GridViewColumn>
                    <GridViewColumn.CellTemplate>
                            <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <Image Width="16" Name="Test" Height="16" Source="{Binding Path=ImagePath,Mode=TwoWay}"/>
                                <TextBlock Text="Status"/>
                            </StackPanel>
                            <DataTemplate.Triggers>
                                <DataTrigger Binding="{Binding IsChecked}" Value="True">
                                    <Setter Property="Source" Value="{Binding Path=ImagePath2}" TargetName="Test" />
                                </DataTrigger>
                            </DataTemplate.Triggers>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
            </GridView>
        </ListView.View>
    </ListView>
