                <TreeView Grid.Row="1"  Name="treeView" Margin="5">
                <TreeView.ItemContainerStyle>
                    <Style TargetType="{x:Type TreeViewItem}">
                        <Setter Property="IsExpanded" Value="{Binding IsExpanded, Mode=TwoWay}" />
                        <Setter Property="KeyboardNavigation.AcceptsReturn" Value="True" />
                        <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}" />
                        <!-- Style for the selected item -->
                        <Setter Property="BorderThickness" Value="1"/>
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type TreeViewItem}">
                                    <ControlTemplate.Resources>
                                        <Conv:LeftMarginMultiplierConverter Length="19" x:Key="lengthConverter" />
                                    </ControlTemplate.Resources>
                                    <StackPanel>
                                        <Border 
                                            x:Name="Bd"
                                            Background="{TemplateBinding Background}"
                                            BorderBrush="{TemplateBinding BorderBrush}"
                                            BorderThickness="{TemplateBinding BorderThickness}"
                                            Padding="{TemplateBinding Padding}">
                                            <Grid Margin="{Binding Converter={StaticResource lengthConverter}, RelativeSource={RelativeSource TemplatedParent}}">
                                                <Grid.ColumnDefinitions>
                                                    <ColumnDefinition Width="19" />
                                                    <ColumnDefinition/>
                                                </Grid.ColumnDefinitions>
                                                <ToggleButton 
                                                    Grid.Column="0" 
                                                    x:Name="Expander"
                                                    Style="{StaticResource ExpandCollapseToggleStyle}"
                                                    IsChecked="{Binding Path=IsExpanded, RelativeSource={RelativeSource TemplatedParent}}"
                                                    ClickMode="Press"/>
                                                <ContentPresenter x:Name="PART_Header" Grid.Column="1" VerticalAlignment="Stretch" HorizontalAlignment="Stretch" ContentSource="Header" />
                                            </Grid>
                                        </Border>
                                        <ItemsPresenter x:Name="ItemsHost" />
                                    </StackPanel>
                                    <ControlTemplate.Triggers>
                                        <Trigger Property="IsExpanded" Value="false">
                                            <Setter TargetName="ItemsHost" Property="Visibility" Value="Collapsed"/>
                                        </Trigger>
                                        <Trigger Property="HasItems" Value="false">
                                            <Setter TargetName="Expander" Property="Visibility" Value="Hidden"/>
                                        </Trigger>
                                        <MultiTrigger>
                                            <MultiTrigger.Conditions>
                                                <Condition Property="HasHeader" Value="false"/>
                                                <Condition Property="Width" Value="Auto"/>
                                            </MultiTrigger.Conditions>
                                            <Setter TargetName="PART_Header" Property="MinWidth" Value="75"/>
                                        </MultiTrigger>
                                        <MultiTrigger>
                                            <MultiTrigger.Conditions>
                                                <Condition Property="HasHeader" Value="false"/>
                                                <Condition Property="Height" Value="Auto"/>
                                            </MultiTrigger.Conditions>
                                            <Setter TargetName="PART_Header" Property="MinHeight" Value="19"/>
                                        </MultiTrigger>
                                        <Trigger Property="IsSelected" Value="true">
                                            <!--<Setter TargetName="Bd" Property="Background" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}"/>-->
                                            <Setter TargetName="Bd" Property="Background" Value="#FFF7D280"/>
                                            <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.HighlightTextBrushKey}}"/>
                                        </Trigger>
                                        <MultiTrigger>
                                            <MultiTrigger.Conditions>
                                                <Condition Property="IsSelected" Value="true"/>
                                                <Condition Property="IsSelectionActive" Value="false"/>
                                            </MultiTrigger.Conditions>
                                            <!--<Setter TargetName="Bd" Property="Background" Value="{DynamicResource {x:Static SystemColors.ControlBrushKey}}"/>-->
                                            <Setter TargetName="Bd" Property="Background" Value="#FFDADADA"/>
                                            <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
                                        </MultiTrigger>
                                        <Trigger Property="IsEnabled" Value="false">
                                            <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
                                        </Trigger>
                                    </ControlTemplate.Triggers>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                        <Style.Triggers>
                            <!-- Selected and has focus -->
                            <Trigger Property="IsSelected" Value="True">
                                <Setter Property="BorderBrush" Value="{StaticResource HT_Background_Orange}"/>
                            </Trigger>
                            <!-- Mouse over -->
                            <Trigger Property="IsMouseOver" Value="True">
                                <Setter Property="Background" Value="#FFFDE8BA"/>
                                <!--<Setter Property="Background">
                                    <Setter.Value>
                                        <LinearGradientBrush EndPoint="0,1" StartPoint="0,0">
                                            <GradientStop Color="#FFFAFBFD" Offset="0"/>
                                            <GradientStop Color="#fadfa3" Offset="1"/>
                                        </LinearGradientBrush>
                                    </Setter.Value>
                                </Setter>-->
                                <Setter Property="BorderBrush" Value="#f59246"/>
                            </Trigger>
                            <!-- Selected but does not have the focus -->
                            <MultiTrigger>
                                <MultiTrigger.Conditions>
                                    <Condition Property="IsSelected" Value="True"/>
                                    <Condition Property="IsSelectionActive" Value="False"/>
                                </MultiTrigger.Conditions>
                                <Setter Property="BorderBrush" Value="#f59246"/>
                            </MultiTrigger>
                        </Style.Triggers>
                        <Style.Resources>
                            <Style TargetType="Border">
                                <Setter Property="CornerRadius" Value="0"/>
                            </Style>
                        </Style.Resources>
                    </Style>
                </TreeView.ItemContainerStyle>
                <TreeView.ItemTemplate>
                    <HierarchicalDataTemplate DataType="{x:Type local:FileSystemObjectInfo}" ItemsSource="{Binding Path=Children}">
                        <StackPanel Orientation="Horizontal">
                            <Image
                                Source="{Binding Path=ImageSource, UpdateSourceTrigger=PropertyChanged}" 
                                Margin="0,1,8,1"
                                Height="24"
                                Width="24"/>
                            <TextBlock
                                Text="{Binding Path=FileSystemInfo.Name}"
                                VerticalAlignment="Center"/>
                        </StackPanel>
                    </HierarchicalDataTemplate>
                </TreeView.ItemTemplate>
                <TreeView.Resources>
                    <!-- Brushes for the selected item -->
                    <LinearGradientBrush x:Key="{x:Static SystemColors.HighlightBrushKey}" EndPoint="0,1" StartPoint="0,0">
                        <GradientStop Color="#FFFDF2DA" Offset="0"/>
                        <GradientStop Color="#FFF7D280" Offset="1"/>
                    </LinearGradientBrush>
                    <LinearGradientBrush x:Key="{x:Static SystemColors.ControlBrushKey}" EndPoint="0,1" StartPoint="0,0">
                        <GradientStop Color="White" Offset="0"/>
                        <GradientStop Color="#FFE2E2E2" Offset="1"/>
                    </LinearGradientBrush>
                    <SolidColorBrush x:Key="{x:Static SystemColors.HighlightTextBrushKey}" Color="Black" />
                    <SolidColorBrush x:Key="{x:Static SystemColors.ControlTextBrushKey}" Color="Black" />
                </TreeView.Resources>
            </TreeView>
