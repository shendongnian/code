    public class A : Form
    {
        void buttonOK(...)
        {
            if (Validate())
            {
                ...
            }
        }
        
        virtual bool Validate()
        {
            ...
        }
    }
    public class B : A
    {
        override bool Validate()
        {
            ...
        }
    }
