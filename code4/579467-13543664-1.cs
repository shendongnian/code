    <UserControl>
       <ListView>
           <ListView.ItemTemplate>
               <DataTemplate>
                   <ComboBox ItemsSource="{Binding DataContext.CollectionSource,
                              RelativeSource={RelativeSource FindAncestor, 
                                               AncestorType=UserControl}}"
                             SelectedItem="{Binding YourItemHere}"/>
               </DataTemplate>
           </ListView.ItemTemplate>
       </ListView>
    </UserControl>
