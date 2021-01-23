    <ListBox SelectionMode="Extended">
        <ListBox.ItemContainerStyle>
            <Style TargetType="ListBoxItem">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ListBoxItem">
                            <Grid Background="LightGray" Margin="1">
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="CommonStates">
                                        <VisualState x:Name="Normal"/>
                                        <VisualState x:Name="Disabled"/>
                                        <VisualState x:Name="MouseOver">
                                            <Storyboard>
                                                <ColorAnimation Storyboard.TargetName="UnselectedText"
                                                                Storyboard.TargetProperty="Foreground.Color"
                                                                To="Blue" Duration="0:0:0.1"/>
                                                <ColorAnimation Storyboard.TargetName="SelectedText"
                                                                Storyboard.TargetProperty="Foreground.Color"
                                                                To="Red" Duration="0:0:0.1"/>
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                    <VisualStateGroup x:Name="SelectionStates">
                                        <VisualState x:Name="Unselected"/>
                                        <VisualState x:Name="Selected">
                                            <Storyboard>
                                                <DoubleAnimation Storyboard.TargetName="UnselectedText"
                                                                 Storyboard.TargetProperty="Opacity"
                                                                 To="0" Duration="0:0:0.1"/>
                                                <DoubleAnimation Storyboard.TargetName="SelectedText"
                                                                 Storyboard.TargetProperty="Opacity"
                                                                 To="1" Duration="0:0:0.1"/>
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                                <TextBlock Name="UnselectedText" Margin="2" Text="{TemplateBinding Content}">
                                    <TextBlock.Foreground>
                                        <SolidColorBrush Color="Black"/>
                                    </TextBlock.Foreground>
                                </TextBlock>
                                <TextBlock Name="SelectedText" Margin="2" Text="{TemplateBinding Content}" Opacity="0">
                                    <TextBlock.Foreground>
                                        <SolidColorBrush Color="White"/>
                                    </TextBlock.Foreground>
                                </TextBlock>
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ListBox.ItemContainerStyle>
        <ListBox.Items>
            <ListBoxItem Content="Item 1"/>
            <ListBoxItem Content="Item 2"/>
            <ListBoxItem Content="Item 3"/>
            <ListBoxItem Content="Item 4"/>
            <ListBoxItem Content="Item 5"/>
            <ListBoxItem Content="Item 6"/>
            <ListBoxItem Content="Item 7"/>
            <ListBoxItem Content="Item 8"/>
            <ListBoxItem Content="Item 9"/>
            <ListBoxItem Content="Item 10"/>
        </ListBox.Items>
    </ListBox>
