    struct s
    {
        void test() { }
        void runv1()
        {
            Delegatev2<s, void> d(this);
            d += test;
        }
        void runv2()
        {
            Delegate<void> d;
            auto memd = d.getMemberDelegate(this);
            memd += test;
        }
    };
