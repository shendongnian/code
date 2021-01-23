    <ListView>
     <ListView.View >
        <GridView >
            <!--  other columns you need-->
            <GridViewColumn Header="Versions" >
                <GridViewColumn.CellTemplate>
                    <DataTemplate>
                        <CheckBox IsCheck="{Binding LatestVersion}"/>
                        <CheckBox IsCheck="{Binding CurrentVersion}"/>
                    </DataTemplate>
                </GridViewColumn.CellTemplate>
            </GridViewColumn>
        </GridView>
     </ListView.View>
    </ListView>
    
