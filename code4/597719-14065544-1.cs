    public class OptimizeModels
    {   
        public string SelectedItem { get; set; }
        public IEnumerable<Item> Items 
        {
            get
            {
                return new[] 
                {
                    new Item { Value = "Sales", Text = "Units" },
                    new Item { Value = "RetGM", Text = "Rtlr Gross Margin ($)" },
                    new Item { Value = "MfrGM", Text = "Mfr Gross Margin ($)" },
                };
            }
        }
    }
