    <Style TargetType="{x:Type local:EntityTabItem}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type local:EntityTabItem}">
                    <Border>
                        <Grid>
                            <Border x:Name="borderTop" Background="{TemplateBinding Background}" BorderBrush="{TemplateBinding BorderBrush}"/>
                            <StackPanel Orientation="Horizontal" Margin="0,0,2,0">
                                <!-- Want to bind the FileName to this TextBlock -->
                                <TextBlock VerticalAlignment="Center" Text="{Binding Path=FileName}" Margin="-1,0,0,0" Padding="6,1,10,1"/>
                                <Button x:Name="closeButton" VerticalAlignment="Center" Content="X" Style="{StaticResource TabCloseButton}"/>
                            </StackPanel>
                        </Grid>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
        <Setter Property="ContentTemplate">
            <Setter.Value>
                <DataTemplate>
                    <Grid Background="White">
                        <!-- Want to bind the FileText to this TextBox -->
                        <TextBox Margin="15,0,0,0" BorderBrush="{x:Null}" Text="{Binding Path=FileText}"/>
                    </Grid>
                </DataTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    public class EntityTabItem : TabItem
    {
        private Entity _myEntity;
        public Entity MyEntity
        {
            get { return _myEntity; }
            set
            {
                _myEntity = value;
                DataContext = value;
            }
        }
    
        public EntityTabItem(string path)
        {
            this.MyEntity = new Entity(path);
        }
    
        static EntityTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EntityTabItem), new FrameworkPropertyMetadata(typeof(EntityTabItem)));
        }
    }
