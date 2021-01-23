c#
// Select the Mailbox you want to query
Mailbox Inbox = _client.SelectMailbox("Inbox");
for (int x=Inbox.MessageCount; x>0; x--)
{
    Message email = Inbox.Fetch.MessageObject(x);
    ProcessEmail(email, x);
}
Basically the messageOrdinal is the index of the mail (for example: the position in the gmail Inbox), but you have to keep the reference by yourself because ActiveUp.Net.Mail.Message won't provide any function to retrieve it.
In the `ProcessEmail` function you will receive the `messageOrdinal` as input parameter:
c#
public void ProcessEmail(Message email, int messageOrdinal)
{
    //...
}
