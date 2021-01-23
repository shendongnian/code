    <Page.Resources xmlns:conv="clr-namespace:Project.Converters">
    		<conv:BoolToVisibilityConverter x:Key="boolToVisibilityConverter"/>
            <ItemsPanelTemplate x:Key="ListBox_HorizontalItems">
                <StackPanel Orientation="Horizontal" />
            </ItemsPanelTemplate>
    		
    
    		<DataTemplate x:Key="ImageGalleryDataTemplate" x:Name="ImageGalleryDataTemplate"  >
    			
    			<Grid>
    				<Border BorderBrush="ForestGreen" BorderThickness="3"  Width="120" Height="120" Padding="10" Margin="15" CornerRadius="10">
    					<!--Note: You'll Need Antother Event Somewhere In Here To Switch IsSelected Back To False To Hide It Again.-->
    					<Image Source="{Binding ImagePath}" Stretch="Fill"  HorizontalAlignment="Center" MouseDown="MouseDownEventHandler">
    
    						<Image.ToolTip>
    							<Grid>
    								<Image Source="{Binding ImagePath}" Stretch="Fill" HorizontalAlignment="Center" Height="100" Width="100"></Image>
    
    							</Grid>
    						</Image.ToolTip>
    
    					</Image>
    
    				</Border>
    				<Border>
    					<Grid>
    						<!--I Added Code Here To Only Show The TextBlock Whenever The IsSelected Property On Your ImageEntity Class Is True-->
    						<TextBlock Text="{Binding ItemName_EN}" ToolTip="{Binding ItemName_EN}" Visibility="{Binding Path=IsSelected, Converter={StaticResource boolToVisibilityConverter}}" />
    					</Grid>
    				</Border>
    				<Grid x:Name="LayoutRoot" Background="DarkGreen" >
    					<Button   Click="ButtonClicked" ToolTip="{Binding ItemName_EN}" >
    						<Image Source="{Binding ImagePath}" Stretch="Fill" Height="100" Width="100" HorizontalAlignment="Center"/>
    					</Button>
    				</Grid>
    
    			</Grid>
    		</DataTemplate>
    
            <ItemsPanelTemplate x:Key="ImageGalleryItemsPanelTemplate">
    
                <!--Display Images on UniformGrid Panel-->
                <UniformGrid Columns="4" HorizontalAlignment="Center" VerticalAlignment="Stretch"/>
    
            </ItemsPanelTemplate>
    
        </Page.Resources>
    Class ImageEntity : INotifyPropertyChanged
        {
    		private bool isSelected = false;
    		
            public String ImagePath
            {
                get;
                set;
            }
            public String ItemName_EN
            {
                get;
                set;
            }
    		
    		public bool IsSelected
    		{
    			get {return isSelected};
    			set 
    			{
    				isSelected = value;
    				NotifyPropertyChanged("IsSelected");
    			}
    		}
    		
    		///You Need All Of These To Notify The View That The IsSelected Has Changed So That It Will Update
    		public event PropertyChangedEventHandler PropertyChanged;
    
    		protected virtual void OnPropertyChanged(string propertyName)
    		{
    			if (this.PropertyChanged != null)
    				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    		}
    
    		public void NotifiyPropertyChanged(string property)
    		{
    			if (PropertyChanged != null)
    				PropertyChanged(this, new PropertyChangedEventArgs(property));
    		}
    
        }
    	
    	///You Need This To Convert The IsSelected Property Above To A Visibility Enum. This Is Used In Your XAML
    	namespace Project.Converters
    	{
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Windows.Data;
    
        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public class BoolToVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value.ToString().ToLower() == "false")
                    return System.Windows.Visibility.Visible;
                else
                    return System.Windows.Visibility.Collapsed;
                //throw new NotImplementedException();
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    	}
    class InVoice
    {
    	private void BindImages()
    	{
    		try
    		{
    			// Store Data in List Object
    			List<ImageEntity> ListImageObj = ImageView.GetAllImagesData();
    
    			// Check List Object Count
    			if (ListImageObj.Count > 0)
    			{
    				// Bind Data in List Box Control.
    				LsImageGallery.DataContext = ListImageObj;
    
    
    			}
    		}
    		catch (Exception ex)
    		{
    			throw new Exception(ex.Message);
    		}
    	}
    	void MouseDownEventHandler(object sender, MouseButtonEventArgs e)
    	{
    		//Here You'll Probably Need To Cast sender To A FrameworkElement Or Something In Order To Get The Instance Of The ImageEntity That Was Clicked
    		//After You Do This, You Can Set The IsSelected Property For The Item To True, And The ItemName_EN Should Automatically Show.
    	}
    	
    
    }
