    <TabControl Background="#123" TabStripPlacement="Left" HorizontalAlignment="Stretch" BorderBrush="#41020202">
                <TabControl.BitmapEffect>
                    <DropShadowBitmapEffect Color="Black" Direction="270"/>
                </TabControl.BitmapEffect>
                <TabControl.Resources>
                    <Style TargetType="{x:Type TabPanel}">
                        <Setter Property="Background" Value="Yellow"/>
                    </Style>
                    <Style TargetType="{x:Type TabItem}">
                        <Setter Property="BorderThickness" Value="0"/>
                        <Setter Property="Padding" Value="0" />
                        <Setter Property="HeaderTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <Border x:Name="grid" Background="Red">
                                        <ContentPresenter>
                                            <ContentPresenter.Content>
                                                <TextBlock Margin="4" FontSize="15" Text="{TemplateBinding Content}"/>
                                            </ContentPresenter.Content>
                                            <ContentPresenter.LayoutTransform>
                                                <RotateTransform Angle="270" />
                                            </ContentPresenter.LayoutTransform>
                                        </ContentPresenter>
                                    </Border>
                                    <DataTemplate.Triggers>
                                        <DataTrigger Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor,AncestorType={x:Type TabItem}},Path=IsSelected}" Value="True">
                                            <Setter TargetName="grid" Property="Background" Value="Green"/>
                                        </DataTrigger>
                                    </DataTemplate.Triggers>
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </TabControl.Resources>
                <TabItem Header="Tab Item 1" />
                <TabItem Header="Tab Item 2" />
                <TabItem Header="Tab Item 3" />
                <TabItem Header="Tab Item 4" />
            </TabControl>
