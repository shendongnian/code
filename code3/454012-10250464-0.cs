    public static object syncLock = new object();
    private static bool myFirstBool;
    private static bool mySecondBool;
    private static bool FirstBool {
        get { return myFirstBool; }
        set {
            lock (syncLock) {
                if (value && mySecondBool) {
                    CallbackMethod(null);
                }
                myFirstBool = value;
            }
        }
    }
    private static bool SecondBool {
        get { return mySecondBool; }
        set {
            lock (syncLock) {
                if (value && myFirstBool) {
                    CallbackMethod(null);
                }
                mySecondBool = value;
            }
        }
    }
