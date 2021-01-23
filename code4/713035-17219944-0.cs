    public partial class _Default : Page
    {
        private Dictionary<Int32,CheckBox> _myDynamicCheckBoxes;
        
        protected override void OnInit(EventArgs e)
        {
            _myDynamicCheckBoxes = new Dictionary<Int32,CheckBox>();
    
            foreach (var product in _listOfProducts)
            {
                var chkBox = new CheckBox {ID = "CheckBox" + product.ID.ToString()};
                _myDynamicCheckBoxes.Add(product.ID,chkBox);
                //add the checkbox to a Controls collection
            }
        }
    }
