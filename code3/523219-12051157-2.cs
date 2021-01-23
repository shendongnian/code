    <ItemsControl ... AlternationCount="2147483647">
    ...
    <ItemsControl.ItemTemplate>
        <DataTemplate>
            <StackPanel Orientation="Horizontal">
                <Button Click="Button_Click"
                        Tag="{Binding RelativeSource={RelativeSource Mode=TemplatedParent},
                                      Path=(ItemsControl.AlternationIndex)}">
                ...
            </StackPanel>
            ...
        </DataTemplate>
    </ItemsControl.ItemTemplate>
