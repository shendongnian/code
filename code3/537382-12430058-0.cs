    static Dictionary<string, Action> switchReplacement = 
        new Dictionary<string, Action>() {
            { PID_1, action1 }, 
            { PID_2, action2 }, 
            { PID_3, action3 }};
    // ... Where action1, action2, and action3 are static methods with no arguments
    // Later, instead of switch, you simply call
    switchReplacement[pid].Invoke();
    
    
