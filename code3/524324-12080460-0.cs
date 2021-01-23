    //this would go in your entity class 
    public int GetNotificationCount()
    {    
       MethodInfo mi = typeof(HelperClass).GetMethod(this.NotificationMethodName);    
       return (int)mi.Invoke(this, null); 
    }
    public class HelperClass
    {
      //your class that currently has all the methods to get notification count
    }
