    public class RawValuesEditingViewModel
    {
        // Your primary ID
        public int Pk { get; set; }
        [Required]
        public int? SelectedCapsulePk { get; set; }
        // Other basic fields as needed for editing on this screen
        public int Active1 { get; set; }
        public int Active2 { get; set; }
        public int Active3 { get; set; }
        public int Active4 { get; set; }
        public int Active5 { get; set; }
        public int KeyActive { get; set; }
        // blah blah blah....
        // Use this as the source for your Dropdown List for the capsule choice
        public IEnumerable<SelectListItem> CapsulesToSelectFrom
        {
            get
            {
                return from cap in DatabaseRepository.GetAllCapsules() // or some kind of Repo here.
                       select new SelectListItem {
                           Text = cap.Name,
                           Value = cap.Pk.ToString(),
                           Selected = (cap.Pk == this.SelectedCapsulePk), 
                       };
            }
        }
        public RawValuesEditingViewModel()
        {
            // This constructor is parameter-less because the MVC model binder needs it this way to bind on post back.
            // You can alter this behavior, but it gets hairy.
        }
        // Call this method from your Controller to populate the ViewModel fields. 
        public void LoadModelFieldsFromDataObject(int pkToLoadFrom)
        {
            // get the underlying database object, from EF in your case.
            var rawValuesObj = DatabaseRepository.GetRawValueObjectById(pkToLoadFrom);
            // Map your RawValues data object fields to the RawValuesEditingViewModel fields as needed.
            // Only map the fields you want to present for editing.
            // Check out "AutoMapper" if you are tired of writing this kind of code :)
            this.Pk = rawValuesObj.Pk;
            this.SelectedCapsulePk = rawValuesObj.CapsuleFk; 
            // etc etc etc
        }
        public void ExecuteRawValuesUpdate(int pk)
        {
            // code to persist back to database goes here.
            // probably you will re-fetch the database object, update its fields from this ViewModels fields, then persist it back thru EF.
        }
    }
