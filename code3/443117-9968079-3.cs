    <TreeViewItem>
        <TreeViewItem.Header>
            <StackPanel Orientation="Horizontal">
                <ContentControl xml:space="preserve">Name: </ContentControl>
                <ContentControl DataContext="{Binding Path=DataContext,RelativeSource={RelativeSource AncestorType=TreeViewItem},Converter={StaticResource NameConverter}}"
                                Content="{Binding Name}"/>
            </StackPanel>
        </TreeViewItem.Header>
    </TreeViewItem>
