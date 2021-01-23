    <ItemsControl ItemsSource="{Binding SomeCollectionOfViewModel}">
       <ItemsControl.ItemsPanel>
          <ItemsPanelTemplate>
             <UniformGrid/>
          </ItemsPanelTemplate>
       </ItemsControl.ItemsPanel>
       <ItemsControl.ItemTemplate>
           <DataTemplate>
              <ItemsControl ItemsSource="{Binding SomeCollection}">   <!-- Nested Content -->
                  ...
           </DataTemplate>
       <ItemsControl.ItemTemplate>
    </ItemsControl>
