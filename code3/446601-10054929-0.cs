       private List<> source8 = new Values8(){ITEMS8 = "Lacasera ", PRICE8 = 290}, new Values8(){ITEMS8 = "Cran-Orange Chiller ", PRICE8 = 290}, new Values8(){ITEMS8 = "Festive Fruity Flavored Milk  ", PRICE8 = 290}, 
        new Values8(){ITEMS8 = "Homemade Iced Coffee ", PRICE8 = 290}, new Values8(){ITEMS8 ="Lemon Cucumber Seltzer " , PRICE8 = 290}, new Values8(){ITEMS8 = "Fizzy Water ", PRICE8 = 290}, 
        new Values8(){ITEMS8 ="Haunted (Black Cauldron) Punch  " , PRICE8 = 290}, new Values8(){ITEMS8 ="Lemon Ginger Iced Green Tea " , PRICE8 = 290}, new Values8(){ITEMS8 ="Orange Creamsicle Shake " , PRICE8 = 290}, 
        new Values8(){ITEMS8 = "Blueberry Blast Smoothie ", PRICE8 = 290}, new Values8(){ITEMS8 ="Shamrock Milk Mixer " , PRICE8 = 290}, new Values8(){ITEMS8 = "Pomegranate Punch  ", PRICE8 = 290}, 
        new Values8(){ITEMS8 ="anned Milo " , PRICE8 = 290}, new Values8(){ITEMS8 ="Viju Milk " , PRICE8 = 290}, new Values8(){ITEMS8 = "5 Alive ", PRICE8 = 290}, 
        new Values8(){ITEMS8 ="Cherry Vanilla Smoothie  " , PRICE8 = 290}, new Values8(){ITEMS8 = "Boysenberry-Banana Blast ", PRICE8 = 290}, new Values8(){ITEMS8 = "Vanilla Iced Mochaccino  ", PRICE8 = 290}, 
        new Values8(){ITEMS8 ="Choco-Nana Milk Mixer " , PRICE8 = 290}, new Values8(){ITEMS8 = "Fresh Fruit Pudding Milk Mixer ", PRICE8 = 290}, new Values8(){ITEMS8 ="Luscious Licuado  " , PRICE8 = 290}, 
        new Values8(){ITEMS8 = "Frosty Pine-Orange Yogurt Smoothie ", PRICE8 = 290}, new Values8(){ITEMS8 = "Mocha-ccino Freeze ", PRICE8 = 290}, new Values8(){ITEMS8 ="Lite Iced Mocha " , PRICE8 = 290}, 
        new Values8(){ITEMS8 ="Nectarine Whirl " , PRICE8 = 290}, new Values8(){ITEMS8 ="Strawberries and Cream Smoothie  " , PRICE8 = 290}, new Values8(){ITEMS8 ="Strawberry Light Lemonade " , PRICE8 = 290};
    public BeveragesAndJuices()
    {
        InitializeComponent();
        gridBeveragesAndJuices.ItemsSource = Source8;  // move this to XAML Binding
    }
    public class Values8 
    {
        public string ITEMS8 
        { 
            get; 
            set
            {
                 Debug.WriteLine(value);
                 // this is where you do the update
            } 
        }
        public decimal PRICE8 { get; set; }
    }
    public List<Values8> Source8
    {
        get { return source8; }
        
    }
    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        //clear the elements of the source  
        //Source8.Clear(); for sure you don't want to do this  !
        //get the items on the datagrid and use them to form new elements of the 
        //Source8
        // do this is the set
        //foreach(DataGridRow Row in gridBeveragesAndJuices)
        //{
            //this where am stuck, foreach flags an error
            //that DataGridRow does not have a definition for GetEnumerator
        //}
    }
