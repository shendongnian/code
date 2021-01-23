    <TabControl ItemsSource="{Binding CoilItems}">
        <TabControl.Resources>
            <local:ItemsControlIndexConverter x:Key="IndexConverter"/>
        </TabControl.Resources>
        <TabControl.ItemTemplate>
             <DataTemplate>
                 <StackPanel Orientation="Horizontal">
                     <TextBlock>
                         <TextBlock.Text>
                             <MultiBinding Converter="{StaticResource IndexConverter}" StringFormat="Order {0}" Mode="OneWay">
                                 <Binding RelativeSource="{RelativeSource AncestorType=TabControl}" Path="Items"/> <!-- First converter index is the ItemsCollection -->
                                 <Binding /> <!-- Second index is the content of this tab -->
                             </MultiBinding>
                         </TextBlock.Text>
                     </TextBlock>
                     <!-- Fill in the rest of the header template -->
                 </StackPanel>
             </DataTemplate>
         </TabControl.ItemTemplate>
     </TabControl>
