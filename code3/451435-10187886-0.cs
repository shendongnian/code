       <TabControl>
            <TabItem Header="A">
                <WebBrowser Source="http://www.google.com/" />
            </TabItem>
            <TabItem Header="B">
                <WebBrowser Source="http://www.bing.com/" />
            </TabItem>
            <TabItem Header="C">
                <WebBrowser Source="http://www.yahoo.com/" />
            </TabItem>
            <Control.Template>
                <ControlTemplate TargetType="TabControl">
                    <DockPanel>
                        <TabPanel IsItemsHost="True"
                                  DockPanel.Dock="{TemplateBinding TabStripPlacement}" />
                        <ListBox ItemsSource="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Items}"
                                 SelectedIndex="{TemplateBinding SelectedIndex}">
                            <ItemsControl.ItemsPanel>
                                <ItemsPanelTemplate>
                                    <Grid />
                                </ItemsPanelTemplate>
                            </ItemsControl.ItemsPanel>
                            <ItemsControl.ItemContainerStyle>
                                <Style TargetType="ListBoxItem">
                                    <Setter Property="Template">
                                        <Setter.Value>
                                            <ControlTemplate TargetType="ListBoxItem">
                                                <ContentPresenter Content="{Binding Content}"
                                                                  ContentTemplate="{Binding ContentTemplate}"
                                                                  ContentTemplateSelector="{Binding ContentTemplateSelector}" />
                                            </ControlTemplate>
                                        </Setter.Value>
                                    </Setter>
                                    <Setter Property="Visibility"
                                            Value="Hidden" />
                                    <Style.Triggers>
                                        <Trigger Property="IsSelected"
                                                 Value="True">
                                            <Setter Property="Visibility"
                                                    Value="Visible" />
                                        </Trigger>
                                    </Style.Triggers>
                                </Style>
                            </ItemsControl.ItemContainerStyle>
                        </ListBox>
                    </DockPanel>
                </ControlTemplate>
            </Control.Template>
        </TabControl>
