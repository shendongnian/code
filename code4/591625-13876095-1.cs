    <ContentControl Grid.Row="0"  
         yourNamespace:AnimatedSwitch.Binding="{Binding CurrentPage}"   
         yourNamespace:AnimatedSwitch.Property="Content">
                <ContentControl.Resources>
                    <DataTemplate DataType="{x:Type vm:SomeVM}">
                        <view:SomeView />
                    </DataTemplate>
                    <DataTemplate DataType="{x:Type vm:SomeOtherVM}">
                        <view:SomeOtherView />
                    </DataTemplate>
                </ContentControl.Resources>
     </ContentControl>
