    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <ListView Grid.Row="0" Grid.Column="0" ItemsSource="{Binding Path=Numbers}" Width="100" Height="500">
            <ListView.RenderTransform>
                <RotateTransform Angle="90" CenterX="150" CenterY="150"/>
            </ListView.RenderTransform> 
        </ListView>
    </Grid>
    
    public List<string> Numbers
    {
        get
        {
            List<string> numbers = new List<string>();
            for (UInt16 i=1; i < 60000; i++)
            {
                numbers.Add(i.ToString());
            }
            return numbers;
        }
    }
