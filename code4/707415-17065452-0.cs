    <TabControl>
       <TabControl.Resources>
          <DataTemplate DataType="{x:Type vm:UserControl1ViewModel}">
             <v:UserControl1View/>
          </DataTemplate>
          <DataTemplate DataType="{x:Type vm:UserControl2ViewModel}">
             <v:UserControl2View/>
          </DataTemplate>
       </TabControl.Resources>
       <TabControl.ItemTemplate>
          <DataTemplate>
             <TextBlock Text="Header"/>
          </DataTemplate>
       </TabControl.ItemTemplate>
    </TabControl>
 
