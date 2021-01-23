                    <HierarchicalDataTemplate  DataType="{x:Type cr:TreeViewWithIcons}" ItemsSource="{Binding Path=ChildNodes,Mode=OneTime}">                       
                            <StackPanel Orientation="Horizontal" Name="stackpanel" IsEnabled="False" >
                            <Image Source="{Binding Path=Icon}"/>
                            <TextBlock Name="HeaderTextBlock" Text="{Binding Path=HeaderText}" Background="{Binding Path=BackgroundColor,Mode=TwoWay,NotifyOnSourceUpdated=True}" Foreground="{Binding Path=HeaderColor,Mode=TwoWay,NotifyOnSourceUpdated=True}" IsEnabled="False">
                            </TextBlock>
                        </StackPanel>
                        <HierarchicalDataTemplate.Triggers>
                            <DataTrigger Binding="{Binding RelativeSource= {RelativeSource Mode=FindAncestor, AncestorType= {x:Type TreeViewItem}},Path=IsSelected}" Value="True">
                                <Setter TargetName="HeaderTextBlock" Property="Foreground" Value="Red"/>
                                <Setter TargetName="stackpanel" Property="Background" Value="LightGray"/>
                                <Setter TargetName="HeaderTextBlock" Property="Background" Value="LightGray"/>
                                <Setter Property="BitmapEffect">
                                    <Setter.Value>
                                        <OuterGlowBitmapEffect GlowColor="Black" />
                                    </Setter.Value>
                                </Setter>
                            </DataTrigger>
                            <DataTrigger Binding="{Binding Path=IsSelected,RelativeSource={RelativeSource TemplatedParent}}" Value="True">
                                <Setter TargetName="HeaderTextBlock" Property="Foreground" Value="Purple"/>
                                <Setter TargetName="HeaderTextBlock" Property="Visibility" Value="Visible"/>
                            </DataTrigger>
                        </HierarchicalDataTemplate.Triggers>
                    </HierarchicalDataTemplate>
                </ResourceDictionary>
            </cr:ExtendedTreeView.Resources>
