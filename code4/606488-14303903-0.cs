    <ListBox ItemsSource="{Binding MyItems}">
       <ListBox.ItemTemplate>
          <DataTemplate>           
             <Grid>
                <Grid.ColumnDefinitions>
                   <ColumnDefinition Width="Auto" />
                   <ColumnDefinition Width="*" />
                </Grid.ColumnDefinitions>
                <Image Grid.Column="0" Source="/Images/.." Width=".." Height=".." />
                <TextBlock Grid.Column="1" Text="{Binding Name}" />
             </Grid>
          </DataTemplate>
       </ListBox.ItemTemplate>
    </ListBox>
