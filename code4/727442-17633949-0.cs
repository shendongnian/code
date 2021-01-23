     public class NewsItem
        {
            public string ImageUri { get; set; }
            public IEnumerable<string> Paragraphs { get; set; }        
        }
    <DataTemplate x:Key="newsTemplate">
    			<Grid Height="105" Width="441">
    				<Grid.ColumnDefinitions>
    					<ColumnDefinition Width="97*"/>
    					<ColumnDefinition Width="344*"/>
    				</Grid.ColumnDefinitions>
    				<Image Grid.ColumnSpan="2" HorizontalAlignment="Left" Height="100" VerticalAlignment="Top" Width="100"/>
                    <ListBox Grid.Column="1" ItemsSource="{Binding Paragraphs}"></ListBox>
    			</Grid>
    		</DataTemplate>
    <Grid x:Name="colorPlace" Grid.Row="1" Margin="12,0,12,0"/>        
    <ListBox Grid.Row="1" Name="newList" ItemTemplate="{StaticResource newsTemplate}">
        
    </ListBox>
    </Grid>
