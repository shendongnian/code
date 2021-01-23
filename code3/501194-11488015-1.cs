    <Window.Resources>
        <local:ListToStringConverter x:Key="listFormatter" /> // assumming you imported the namespace
    </Window.Resources>
  
    <ListView x:Name="myCab">
        <ListView.View>
            <GridView>
                <GridViewColumn Width="140" Header="Medication" DisplayMemberBinding="{Binding Medication}" />
                <GridViewColumn Width="140" Header="Stations" DisplayMemberBinding="{Binding Path=Stations Converter={StaticResource listFormatter}}">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding}"/>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
                <GridViewColumn Width="140" Header="Column 3" />
            </GridView>
        </ListView.View>
    </ListView>
