csharp
public async Task DoTasks(List<Items> items)
{
    foreach (var item in items)
    {
        await Task.Delay(2 * 1000);
        DoWork(item);
    }
}
You can await the completion of this method as follows:
csharp
public async void TaskCaller(List<Item> items)
{
    await DoTasks(items);
}
