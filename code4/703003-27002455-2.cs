    namespace CustomerContent
    {
    public class Customer
    {
    public string CustomerCode = "";
    public string CustomerName = "";
    public void ADD()
    {
       //my DB code will go here
    }
    
    private bool Validate()
    {
        //Granular Customer Code and Name
        return true;
    }
    
    private bool CreateDBObject()
    {
        //DB Connection Code
        return true;
    }
    
    
    class Program
    {
    static void main(String[] args)
    {
    CustomerComponent.Customer obj = new CustomerComponent.Customer;
    
    obj.CustomerCode = "s001";
    
    obj.CustomerName = "Mac";
    
    obj.ADD();
    }
    }
