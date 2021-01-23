    IEnumerable<IOrder> orders = orderService.GetAll();
    // TODO: Create emails from orders by using OrderToEmailAdaptor
    IEnumerable<IEmail> emails = ... 
    emailService.SendEmails(emails);
    public sealed class EmailService
    {
        public void SendEmails(IEnumerable<IEmail> emails)
        {
        }
    }
