    <ListBox ItemsSource="{Binding ContentItems}" ...>
       <ListBox.ItemTemplate>
          <DataTemplate>
             <Grid>
                <ListBox ItemsSource="{Binding}">
                   <ListBox.ItemTemplate>
                     <DataTemplate>
                        <Grid>
                           <TextBlock Text="{Binding MyContentItemViewModelProperty}" />
                        </Grid>
                     </DataTemplate>
                   </ListBox.ItemTemplate>
                </ListBox>
             </Grid>
          </DataTemplate>
        <ListBox.ItemTemplate>
     </ListBox>
