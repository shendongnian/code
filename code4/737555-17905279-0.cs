    <!-- ScrollBar Brushes -->
    <SolidColorBrush x:Key="GlyphBrush" Color="#F2F2F2" />
    <SolidColorBrush x:Key="ScrollBarBackBrush" Color="#383E4A" />
    <SolidColorBrush x:Key="ThumbBackBrush" Color="#999999" /> 
    <SolidColorBrush x:Key="PressedBrush" Color="Gray" />
    
    <!-- **************** ScrollBar **************** -->
    <!-- ScrollBar Line Button Style -->
    <Style x:Key="ScrollBarLineButton" TargetType="{x:Type RepeatButton}">
        <Setter Property="SnapsToDevicePixels" Value="True"/>
        <Setter Property="OverridesDefaultStyle" Value="true"/>
        <Setter Property="Focusable" Value="false"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type RepeatButton}">
                    <Border Name="Border"
                            Margin="1"
                            Background="{TemplateBinding Background}"
                            BorderBrush="Transparent"
                            BorderThickness="1">
                        <Path x:Name="_path"
                              HorizontalAlignment="Center"                              
                              VerticalAlignment="Center"
                              Fill="{DynamicResource GlyphBrush}"
                              Data="{Binding Path=Content,RelativeSource={RelativeSource TemplatedParent}}" />
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsPressed" Value="true">
                            <Setter TargetName="Border" Property="Background" Value="{DynamicResource PressedBrush}" />
                        </Trigger>
                        <Trigger Property="IsEnabled" Value="false">
                            <Setter TargetName="_path" Property="Fill" Value="{DynamicResource DisabledForegroundBrush}"/>
                            <Setter TargetName="Border" Property="Background" Value="{DynamicResource DisabledBackgroundBrush}"/>
                            <Setter TargetName="Border" Property="BorderBrush" Value="{DynamicResource DisabledBorderBrush}"/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    <!-- ScrollBar Page Button Style -->
    <Style x:Key="ScrollBarPageButton" TargetType="{x:Type RepeatButton}">
        <Setter Property="SnapsToDevicePixels" Value="True"/>
        <Setter Property="OverridesDefaultStyle" Value="true"/>
        <Setter Property="IsTabStop" Value="false"/>
        <Setter Property="Focusable" Value="false"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type RepeatButton}">
                    <Border Background="Transparent" />
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    <!-- ScrollBar Thumb Style -->
    <Style x:Key="VerticalScrollBarThumb" TargetType="{x:Type Thumb}">
        <Setter Property="SnapsToDevicePixels" Value="True"/>
        <Setter Property="OverridesDefaultStyle" Value="true"/>
        <Setter Property="IsTabStop" Value="false"/>
        <Setter Property="Focusable" Value="false"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type Thumb}">
                    <Border Background="{TemplateBinding Background}"
                            BorderBrush="Transparent"
                            BorderThickness="1"  >
                        <!--<Rectangle Width="8" Height="25">
                            <Rectangle.Fill>
                                <DrawingBrush Viewport="0,0,4,4" ViewportUnits="Absolute" Stretch="None" TileMode="Tile">
                                    <DrawingBrush.Drawing>
                                        <DrawingGroup>
                                            <GeometryDrawing Brush="White">
                                                <GeometryDrawing.Geometry>
                                                    <GeometryGroup>
                                                        <RectangleGeometry Rect="0,0,1,1"/>                                                        
                                                    </GeometryGroup>
                                                </GeometryDrawing.Geometry>
                                            </GeometryDrawing>                                            
                                        </DrawingGroup>
                                    </DrawingBrush.Drawing>
                                </DrawingBrush>
                            </Rectangle.Fill>
                        </Rectangle>-->
                    </Border>
               </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    <Style x:Key="HorizontalScrollBarThumb" TargetType="{x:Type Thumb}">
        <Setter Property="SnapsToDevicePixels" Value="True"/>
        <Setter Property="OverridesDefaultStyle" Value="true"/>
        <Setter Property="IsTabStop" Value="false"/>
        <Setter Property="Focusable" Value="false"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type Thumb}">
                    <Border Background="{TemplateBinding Background}"
                            BorderBrush="Transparent"
                            BorderThickness="1" >
                        <!--<Rectangle Width="31" Height="8">
                            <Rectangle.Fill>
                                <DrawingBrush Viewport="0,0,4,4" ViewportUnits="Absolute" Stretch="None" TileMode="Tile">
                                    <DrawingBrush.Drawing>
                                        <DrawingGroup>
                                            <GeometryDrawing Brush="White">
                                                <GeometryDrawing.Geometry>
                                                    <GeometryGroup>
                                                        <RectangleGeometry Rect="0,0,1,1"/>
                                                    </GeometryGroup>
                                                </GeometryDrawing.Geometry>
                                            </GeometryDrawing>
                                        </DrawingGroup>
                                    </DrawingBrush.Drawing>
                                </DrawingBrush>
                            </Rectangle.Fill>
                        </Rectangle>-->
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    <!-- Vertical ScrollBar Control Template -->
    <ControlTemplate x:Key="VerticalScrollBar" TargetType="{x:Type ScrollBar}">
        <Grid >
            <Grid.RowDefinitions>
                <RowDefinition MaxHeight="18"/>
                <RowDefinition Height="0.00001*"/>
                <RowDefinition MaxHeight="18"/>
            </Grid.RowDefinitions>
            
            <Border Grid.RowSpan="3"
                    BorderThickness="0"
                    Background="{DynamicResource BaseColor}" />
            
            <RepeatButton Grid.Row="0"                           
                          Style="{StaticResource ScrollBarLineButton}"
                          Height="18"
                          Command="ScrollBar.LineUpCommand"
                          Content="M 0 4 L 8 4 L 4 0 Z"
                          Background="{DynamicResource ThumbBackBrush}"/>
            
            <Track Name="PART_Track"
                   Grid.Row="1"
                   IsDirectionReversed="true">
                <Track.DecreaseRepeatButton>
                    <RepeatButton Style="{StaticResource ScrollBarPageButton}"
                                  Command="ScrollBar.PageUpCommand" />
                </Track.DecreaseRepeatButton>                
                <Track.Thumb>
                    <Thumb Style="{StaticResource VerticalScrollBarThumb}" 
                           Margin="1,0,1,0"  
                           Background="{DynamicResource ThumbBackBrush}" />
                </Track.Thumb>
                <Track.IncreaseRepeatButton>
                    <RepeatButton Style="{StaticResource ScrollBarPageButton}"
                                  Command="ScrollBar.PageDownCommand" />
                </Track.IncreaseRepeatButton>
            </Track>
            <RepeatButton Grid.Row="3" 
                          Style="{StaticResource ScrollBarLineButton}"
                          Height="18"
                          Command="ScrollBar.LineDownCommand"
                          Content="M 0 0 L 4 4 L 8 0 Z"
                          Background="{DynamicResource ThumbBackBrush}"/>
        </Grid>
    </ControlTemplate>
    <!-- Horizontal ScrollBar Control Template -->
    <ControlTemplate x:Key="HorizontalScrollBar" TargetType="{x:Type ScrollBar}">
        <Grid >
            <Grid.ColumnDefinitions>
                <ColumnDefinition MaxWidth="18"/>
                <ColumnDefinition Width="0.00001*"/>
                <ColumnDefinition MaxWidth="18"/>
            </Grid.ColumnDefinitions>
            <Border Grid.ColumnSpan="3"
                    BorderThickness="0"                    
                    Background="{DynamicResource BaseColor}"/>
            <RepeatButton Grid.Column="0"                           
                          Style="{StaticResource ScrollBarLineButton}"
                          Width="18"
                          Command="ScrollBar.LineLeftCommand"
                          Content="M 4 0 L 4 8 L 0 4 Z" 
                          Background="{DynamicResource ThumbBackBrush}"/>
            <Track Name="PART_Track"
                   Grid.Column="1"
                   IsDirectionReversed="False">
                <Track.DecreaseRepeatButton>
                    <RepeatButton Style="{StaticResource ScrollBarPageButton}"
                                  Command="ScrollBar.PageLeftCommand" />
                </Track.DecreaseRepeatButton>
                <Track.Thumb>
                    <Thumb Style="{StaticResource HorizontalScrollBarThumb}"        
                           Margin="0,1,0,1"  
                           Background="{DynamicResource ThumbBackBrush}" />
                </Track.Thumb>
                <Track.IncreaseRepeatButton>
                    <RepeatButton Style="{StaticResource ScrollBarPageButton}"
                                  Command="ScrollBar.PageRightCommand" />
                </Track.IncreaseRepeatButton>
            </Track>
            <RepeatButton Grid.Column="3" 
                          Style="{StaticResource ScrollBarLineButton}"
                          Width="18"
                          Command="ScrollBar.LineRightCommand"
                          Content="M 0 0 L 4 4 L 0 8 Z"
                          Background="{DynamicResource ThumbBackBrush}"/>
        </Grid>
    </ControlTemplate>
    <!-- ScrollBar Style -->
    <Style x:Key="{x:Type ScrollBar}" TargetType="{x:Type ScrollBar}">
        <Setter Property="SnapsToDevicePixels" Value="True"/>
        <Setter Property="OverridesDefaultStyle" Value="true"/>
        <Style.Triggers>
            <Trigger Property="Orientation" Value="Horizontal">
                <Setter Property="Width" Value="Auto"/>
                <Setter Property="Height" Value="15" />
                <Setter Property="Template" Value="{StaticResource HorizontalScrollBar}" />
            </Trigger>
            <Trigger Property="Orientation" Value="Vertical">
                <Setter Property="Width" Value="15"/>
                <Setter Property="Height" Value="Auto" />
                <Setter Property="Template" Value="{StaticResource VerticalScrollBar}" />
            </Trigger>
        </Style.Triggers>
    </Style>
