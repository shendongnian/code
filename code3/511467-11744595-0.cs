    interface IEmailer
    {
        void Send(List<Email> email);
    }
    
    class SimpleMailer : IEmailer
    {
        void Send(List<Email> email)
        {
            //do work
        }
    }
    
    class ComplexMailer : IEmailer
    {
        void Send(List<Email> email)
        {
            //do work
        }
    }
