    public async Task SampleDataSource()
    {
        await readTextFileContents("Text_Files/warmup_description.txt");
        var group1 = new SampleDataGroup("Group-1",
                "Warmup",
                "Group Subtitle: 1",
                "Assets/DarkGray.png",
                 ITEM_CONTENT);
