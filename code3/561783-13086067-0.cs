    namespace vCardGenerator.Website
    {
    public partial class SendvCard
    {
        public void Mailvcard()
        {
    
    Mailer smtp = new Mailer(server);
    } // <===== THIS ENDS THE METHOD
        smtp.AddAttachment = (@"C:\\Bureaublad\\FirstName_FamilyName.vcf");
        smtp.FromAddress = "email";
        smtp.Subject = "vCard";
        smtp.MailBody = "In de bijlage vindt u de vCard";
        smtp.AddRecipient = txtMail.Text;
