    <ListBox Name="MyList" 
         SelectionChanged="MyList_SelectionChanged">
        <ListBox.ItemTemplate>
           <DataTemplate>               
               <Grid>
                   <Grid.ColumnDefinitions>
                       <ColumnDefinition Width="*" />
                       <ColumnDefinition Width="*" />
                   </Grid.ColumnDefinitions>
                   <Grid.RowDefinitions>
                       <RowDefinition Height="*" />
                   </Grid.RowDefinitions>
                   <TextBlock Grid.Column="1" Text="{Binding ...}" />
               </Grid> 
           </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
