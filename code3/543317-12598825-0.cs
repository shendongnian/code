    <TabControl TabStripPlacement="Left" Margin="5"  FontSize="13" FontFamily="Verdana" Grid.ColumnSpan="2" SnapsToDevicePixels="True" UseLayoutRounding="True" >
                            <TabControl.Resources>
                                <Style TargetType="{x:Type TabItem}">
                                    <Setter Property="BorderThickness" Value="0"/>
                                    <Setter Property="Padding" Value="0" />
                                    <Setter Property="HeaderTemplate">
                                        <Setter.Value>
                                            <DataTemplate>
                                                <Border x:Name="grid" Margin="0" >
                                                    <Border.LayoutTransform>
                                                        <RotateTransform Angle="270" ></RotateTransform>
                                                    </Border.LayoutTransform>
                                                    <ContentPresenter>
                                                        <ContentPresenter.Content>
                                                            <TextBlock FontFamily="Verdana"   Margin="4"  Text="{TemplateBinding Content}">
    
                                                            </TextBlock>
    
                                                        </ContentPresenter.Content>
                                                    </ContentPresenter>
                                                </Border>
                                            </DataTemplate>
                                        </Setter.Value>
                                    </Setter>
                                </Style>
                            </TabControl.Resources>
                            <TabItem Name="General"   Header="YourHeader"  > ..
