    class ReferenceCounter
    {
    public:
    static int GlobalReferenceCounter;
    static void duplicate() { increaseGlobalCounter(); }
    
    static void release() { decreaseGlobalCounter(); }
    static int getGlobalCounter() { return privateGetGlobalCounter(); }
    private:
    static increaseGlobalCounter(); // implementation into Cpp file
    static decreaseGlobalCounter(); // implementation into Cpp file
    static privateGetGlobalCounter(); // implementation into Cpp file
    
    };
