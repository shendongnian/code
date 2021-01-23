    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using LongListSelectorDemo.Model;
    using Microsoft.Phone.Controls;
    namespace LongListSelectorDemo
    {
        public partial class MainPage : PhoneApplicationPage
        {
            // Constructor
            public MainPage()
            {
                InitializeComponent();
                // Sample code to localize the ApplicationBar
                //BuildLocalizedApplicationBar();
            }
            protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
            {
                base.OnNavigatedTo(e);
                if (GroupedList.ItemsSource == null)
                {
                    var foodItems = new ObservableCollection<FoodItem>();
                    /*---Make burger items---*/
                    foodItems.Add(new FoodItem("Hamburger", "Burgers"));
                    foodItems.Add(new FoodItem("Chicken burger", "Burgers"));
                    foodItems.Add(new FoodItem("Turkey burger", "Burgers"));
                    foodItems.Add(new FoodItem("Black bean burger", "Burgers"));
                    /*---Make fryer items---*/
                    foodItems.Add(new FoodItem("Fries", "Fryer"));
                    foodItems.Add(new FoodItem("Onion rings", "Fryer"));
                    foodItems.Add(new FoodItem("Tater tots", "Fryer"));
                    foodItems.Add(new FoodItem("Mozzarella sticks", "Fryer"));
                    /*---Make fish items---*/
                    foodItems.Add(new FoodItem("Salmon", "Fish"));
                    foodItems.Add(new FoodItem("Rainbow trout", "Fish"));
                    foodItems.Add(new FoodItem("Grilled tilapia", "Fish"));
                    GroupedList.ItemsSource = GroupedItems(foodItems);
                }
            }
            public ObservableCollection<StringKeyGroup<FoodItem>> GroupedItems(IEnumerable<FoodItem> source)
            {
                return StringKeyGroup<FoodItem>.CreateGroups(source,
        System.Threading.Thread.CurrentThread.CurrentUICulture, s => s.GroupName, true);
            }
        }
    }
