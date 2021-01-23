    #pragma pack(1)
    typedef struct VARIABLES
    {
    /*
    Use simple variables, avoid pointers
    If you need to use arrays use fixed size ones
    */
    }variables_t;
    #pragma pack()
    extern "C"
    {
         __declspec(dllexport) int function1(void * variables)
        {
            // some work depending on random and on the "variables"
        }
    }
