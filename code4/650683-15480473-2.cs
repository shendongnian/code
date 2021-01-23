    public class EditAccountViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AboutMe { get; set; }
        public int NewSelectedPrivacyLevel { get; set; }
        public PrivacyLevelViewModel SelectedPrivacyLevel { get; set; }
        
        public SelectList PrivacyLevels
        {
            get
            {
                var items = Enum.GetValues(typeof (PrivacyLevelViewModel))
                    .Cast<PrivacyLevelViewModel>()
                    .Select(viewModel => new PrivacyLevelSelectItemViewModel()
                    {
                        Text = viewModel.DescriptionAttr(),
                        Value = (int)viewModel,
                    });
                //SelectPrivacyLevel was mapped by AutoMapper in the profile from 
                //original entity value to this viewmodel
                return new SelectList(items, "Value", "Text", (int) SelectedPrivacyLevel);
            }
        }
    }
