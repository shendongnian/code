    var a = DoThis(() => ChangeValue(ref obj.value));
    public void ChangeValue(ref int val)
    {
        val = 10;
    }
    public async Task DoThis(Action act)
    {
        var t = new Task(act);
        t.Start();
        await t;
    }
