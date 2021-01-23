    // Nested class, would actually have an unspeakable name
    class CaptureHelper
    {
        public MutableStruct item;
        public void Execute()
        {
            Console.WriteLine(item.Value);
        }
    }
    ...
    // Second loop in main method
    foreach (MutableStruct item in list)
    {
        CaptureHelper helper = new CaptureHelper();
        helper.item = item;
        Action capture = helper.Execute;
        MutableStruct tmp = helper.item;
        Console.WriteLine("Before: {0}", tmp.Value);
        tmp = helper.item;
        tmp.AssignValue(30);
        tmp = helper.item;
        Console.WriteLine("After: {0}", tmp.Value);
    }
