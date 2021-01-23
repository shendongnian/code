    <ListView ItemsSource="{Binding}" SelectionMode="Multiple">
        <!-- add style for the item in list view: -->
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}"/>
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.View>
            <GridView AllowsColumnReorder="True">
                <GridViewColumn Header="Select">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <!-- bind the checkbox to the IsSelected property: -->
                            <CheckBox IsChecked="{Binding IsSelected, Mode=TwoWay}" />
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
                <GridViewColumn DisplayMemberBinding="{Binding Name}" Header="Name" Width="100"/>
            </GridView>
        </ListView.View>
    </ListView>
