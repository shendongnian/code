    class A
    {
        public:
        int pub1;
        private:
        int prvt1;
        protected:
        int proc1;
    };
     
     
    class B : public A
    {
     
        //public int pub1;//This variable is because of inheritacne and is internal.
        //public int proc1;//This variable is because of inheritacne and is internal.
        public:
        int pub2;
        private:
        int prvt2;
        protected:
        int pro2;
    };
     
    int main()
    {
        B* b = new B();
        b->pub2 = 1;
        b->proc1 = 2;
    }
