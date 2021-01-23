    <ListView Grid.Row="1" x:Name="ChatListView" ItemsSource="{TemplateBinding ItemsSource}" 
                                  SelectionMode="None"
                                  IsItemClickEnabled="False"
                                  IsZoomedInView="False"
                        		ShowsScrollingPlaceholders="False"
                        		VerticalContentAlignment="Top" 
                        		  VerticalAlignment="Stretch" 
                                  Margin="10,5">
                            <ListView.ItemContainerStyle>
                                <Style TargetType="ListViewItem">
                                    <Setter Property="HorizontalContentAlignment" Value="Stretch"></Setter>
                                    <Setter Property="Template">
                                        <Setter.Value>
                                            <ControlTemplate TargetType="ListViewItem">
                                                <ContentPresenter/>
                                            </ControlTemplate>
                                        </Setter.Value>
                                    </Setter>
                                </Style>
                            </ListView.ItemContainerStyle>
                            <ListView.ItemContainerTransitions>
                                <TransitionCollection/>
                            </ListView.ItemContainerTransitions>
                            <ListView.Template>
                                <ControlTemplate>
                                    <Border BorderThickness="{TemplateBinding BorderThickness}"
                        					Padding="{TemplateBinding Padding}"
                        					BorderBrush="{TemplateBinding BorderBrush}"
                        					Background="{TemplateBinding Background}">
                                        <ScrollViewer ZoomMode="Disabled" x:Name="ScrollViewer" RenderTransformOrigin="0.5,0.5">
                                            <ScrollViewer.RenderTransform>
                                                <CompositeTransform Rotation="180" ScaleX="-1"/>
                                            </ScrollViewer.RenderTransform>
                                            <ItemsPresenter x:Name="ItemsPresenter"/>
                                        </ScrollViewer>
                                    </Border>
                                </ControlTemplate>
                            </ListView.Template>
                            <ListView.ItemTemplate>
                                <DataTemplate>
                                    <controls:ChatMessageControl Message="{Binding Message}"
                                                                 ChatFrom="{Binding Name}"
                                                                 IsMy="{Binding IsMy}"
                                                                 ShortTime="{Binding CreatedTime}"
                                                                 RenderTransformOrigin="0.5,0.5">
                                        <controls:ChatMessageControl.RenderTransform>
                                            <CompositeTransform Rotation="180" ScaleX="-1"/>
                                        </controls:ChatMessageControl.RenderTransform>
                                    </controls:ChatMessageControl>
                                </DataTemplate>
                            </ListView.ItemTemplate>
                        </ListView>
