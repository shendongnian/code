    <RichTextBox Name="rtb" IsReadOnly="True">
        <FlowDocument>
            <Paragraph>
                <ItemsControl ItemsSource="{Binding col}">
                    <ItemsControl.ItemsPanel>
                        <ItemsPanelTemplate>
                            <WrapPanel/>
                        </ItemsPanelTemplate>
                    </ItemsControl.ItemsPanel>
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <TextBlock>
                                <TextBlock Text="{Binding StaticText,
                                    UpdateSourceTrigger=PropertyChanged}"/><TextBlock Text=" "/>
                            </TextBlock>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </Paragraph>
        </FlowDocument>
    </RichTextBox>
