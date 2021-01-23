    <DataTemplate DataType="{x:Type local:SubSectionViewModel}">
        <StackPanel>
            <Expander Header="{Binding SubSection.SubSectionName}">
                <ItemsControl ItemsSource="{Binding SubSections}"/>
            </Expander>
        </StackPanel>
    </DataTemplate>
    <ItemsControl Name="lstMain" ItemsSource="{Binding Sections}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <GroupBox Header="{Binding Section.SectionName}">
                    <ItemsControl ItemsSource="{Binding SubSections}"/>
                </GroupBox>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
