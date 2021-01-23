    public Result handler (string name, Func<Result> method) {
        Result result = null;
        Log.Say(name + " started!");
        DoSomeMagic();
        try {
            result = method();
        } catch (Exception) {
            Log.Say("Something went terribly wrong");
        }
        return result;
    }
