    namespace vivek
    {
        class viku
        {
            public:
            void func1()
            {
                Console::WriteLine("Base");
            }
        }
    
        class Behera
        {
            static void Main(String[] args)
            {
                viku* v;
                v->func1();
            }
        }
    }
