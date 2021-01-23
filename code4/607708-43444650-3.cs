    <ListBox x:Name="FontFamilyListBox" SelectedIndex="{Binding SelectedIndex, Mode=TwoWay}" Width="{Binding FontFamilyWidth, Mode=TwoWay}"
    		 SelectedItem="{Binding FontFamilyItem, Mode=TwoWay}"
    		 ItemsSource="{Binding FontFamilyItems}"
    		  diag:PresentationTraceSources.TraceLevel="High">
    	<ListBox.ItemTemplate>
    		<DataTemplate DataType="typeData:FontFamilyItem">
    			<Grid>
    				<TextBlock Text="{Binding}" diag:PresentationTraceSources.TraceLevel="High"/>
    
    			</Grid>
    		</DataTemplate>
    	</ListBox.ItemTemplate>
    </ListBox>
    public ObservableCollection<string> fontFamilyItems;
    public ObservableCollection<string> FontFamilyItems
    {
    	get { return fontFamilyItems; }
    	set { SetProperty(ref fontFamilyItems, value, nameof(FontFamilyItems)); }
    }
    
    public string fontFamilyItem;
    public string FontFamilyItem
    {
    	get { return fontFamilyItem; }
    	set { SetProperty(ref fontFamilyItem, value, nameof(FontFamilyItem)); }
    }
    private List<string> GetItems()
    {
    	List<string> fonts = new List<string>();
    	foreach (System.Windows.Media.FontFamily font in Fonts.SystemFontFamilies)
    	{
    		fonts.Add(font.Source);
    		....
    		other stuff..
    	}
    	return fonts;
    }
    public async void OnFontFamilyViewLoaded(object sender, EventArgs e)
    {
    	DisposableFontFamilyViewLoaded.Dispose();
    	Task<List<string>> getItemsTask = Task.Factory.StartNew(GetItems);
    
    	try
    	{
    		foreach (string item in await getItemsTask)
    		{
    			FontFamilyItems.Add(item);
    		}
    	}
    	catch (Exception x)
    	{
    		throw new Exception("Error - " + x.Message);
    	}
    	
    	...
    	other stuff
    }
