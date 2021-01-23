     <FlipView x:Name="FlipView"
                      Grid.Row="5"
                      Width="1040"
                      MinHeight="392"
                      MaxHeight="600"
                      ItemsSource="{Binding Path=CurrentSession.Photos}"
                      Visibility="{Binding CurrentSession.HasContent,
                                           Converter={StaticResource BoolToVisibility}}">
                <FlipView.ItemContainerStyle>
                    <Style TargetType="FlipViewItem">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate>
                                    <Grid Width="1040">
                                        <ScrollViewer HorizontalAlignment="Stretch"
                                                      HorizontalScrollBarVisibility="Auto"
                                                      MaxZoomFactor="4"
                                                      MinZoomFactor="1"
                                                      Tag="{Binding IsSelected}"
                                                      VerticalScrollBarVisibility="Auto"
                                                      VerticalScrollMode="Auto"
                                                      ZoomMode="Enabled"
                                                      extension:ScrollViewerExtension.ScrollViewerZoomFactor="{Binding RelativeSource={RelativeSource TemplatedParent},
                                                                                                                       Path=IsSelected,
                                                                                                                       Converter={StaticResource IsSelectedToZoom}}">
                                            <ContentPresenter />
                                        </ScrollViewer>
                                    </Grid>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </FlipView.ItemContainerStyle>
                <FlipView.ItemTemplate>
                    <DataTemplate>
                        <Image HorizontalAlignment="Stretch" Source="{Binding Path=Path}" />
                    </DataTemplate>
                </FlipView.ItemTemplate>
            </FlipView>
