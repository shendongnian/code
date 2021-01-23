    <TreeViewItem>
        <TreeViewItem.Header>
            <StackPanel Orientation="Horizontal">
                <ContentControl xml:space="preserve">Name: </ContentControl>
                <ContentControl Content="{Binding Converter={StaticResource NameConverter}}"/>
            </StackPanel>
        </TreeViewItem.Header>
    </TreeViewItem>
