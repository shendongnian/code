    <TabControl ItemsSource="{Binding MyItems}">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock>
                <TextBlock.Text>
                    <MultiBinding StringFormat="{} {0}{1}">
                        <Binding Path="HeaderA"/>
                        <Binding Path="HeaderB"/>
                    </MultiBinding>
                </TextBlock.Text>
                </TextBlock>
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate>
            <TextBlock>
                <TextBlock.Text>
                <Binding Path="MyContent"/>
                </TextBlock.Text>
            </TextBlock>
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
