    public static string GetFoo() {
        string source = GameInfoUtil.GetSource(repairRequest, () => {
            return "0"; // this line gives error
        });
    }
