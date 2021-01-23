       <TabControl x:Name="myTabControl">
              <TabControl.Items>
                        <TabItem Header="Tab1">
                            <StackPanel>
                                <TextBlock Text="Tab1 Content" />
                                <Button Content="Go to Tab2" Margin="5" 
                                        HorizontalAlignment="Center" 
                                        Click="Button_Click"/>
                            </StackPanel>
                        </TabItem>
        
                        <TabItem Header="Tab2">
                            <TextBlock Text="Tab2 Content" />
                        </TabItem>
              </TabControl.Items>
       </TabControl>
