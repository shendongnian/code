    public class FVItemData
    {
        //...
        private async void InsertTodoItem(FV_Person fvItem)
        {
            await FVTable.InsertAsync(fvItem);
            items.Add(fvItem);
        }
    }
