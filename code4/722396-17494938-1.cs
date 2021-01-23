    public class FVItemData
    {
        private MobileServiceCollection<FV_Person, FV_Person> items;
        private IMobileServiceTable<FV_Person> FVTable = App.MobileService.GetTable<FV_Person>();
        private async void InsertPerson(FV_Person fvItem)
        {
            await FVTable.InsertAsync(fvItem);
            items.Add(fvItem);
        }
    }
