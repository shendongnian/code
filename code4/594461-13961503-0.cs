    <ListView ItemsSource="{Binding Courses}">
         <ListView.View>
               <GridView>
                    <GridViewColumn Width="120">
                          <GridViewColumnHeader>
                                <TextBlock Text="Course Name"/>
                          </GridViewColumnHeader>
                          <GridViewColumn.CellTemplate>
                               <DataTemplate>
                                    <TextBlock Text="{Binding ...UFigureThisOut}"/>
                               </DataTemplate>
                          </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Width="120">
                          <GridViewColumnHeader>
                                <TextBlock Text="Take That"/>
                          </GridViewColumnHeader>
                          <GridViewColumn.CellTemplate>
                               <DataTemplate>
                                    <CheckBox IsChecked="{Binding ...UFigureThisOutToo}"/>
                               </DataTemplate>
                          </GridViewColumn.CellTemplate>
                    </GridViewColumn> 
               </GridView> 
         </ListView.View>
    </ListView>
